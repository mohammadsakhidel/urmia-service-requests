using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Controllers;

public partial class Views_Shared_SmsReciever : System.Web.UI.Page
{
    SmsRepository sr = new SmsRepository();
    //******************************************
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["From"] != null && Request.QueryString["Message"] != null && MyHelper.IsValidMobNumber(Request.QueryString["From"].ToString()))
            {
                RecievedMessage recieved_sms = save_recieved_sms();
                process_recieved_sms(recieved_sms);
            }
            //////////////////////////////////////////////////////////////////////////////////// show errors:
            if (User.Identity.IsAuthenticated && User.IsInRole(MyRoles.Administrator))
            {
                show_errors();
            }
        }
        catch(Exception ex)
        {
            save_error(ex.Message);
        }
    }

    private void process_recieved_sms(RecievedMessage recieved_sms)
    {
        SmsHelper smsHelper = new SmsHelper();
        ResponseSetting setting = ResponseSetting.Load();
        InformSetting informSetting = InformSetting.Load();
        lblTester.Text = recieved_sms.Type.ToString();
        #region PROCESS Suggestion:
        if (recieved_sms.Type == MyEnums.RecievedMessageType.Suggestion)
        {
            SuggestionsRepository sgr = new SuggestionsRepository();
            //////// save suggestion:
            Suggestion sug = new Suggestion();
            sug.RecievedMessageID = recieved_sms.ID;
            sug.Status = (int)MyEnums.SuggestionStatus.NotRouted;
            sug.PersuitCode = sgr.GetNewPersuitCode();
            sug.Visible = true;
            sug = sgr.Insert(sug);
            //////// route suggestion:
            List<Organization> relatedOrganizations = sgr.GetRelatedOrganizations(sug);
            foreach (Organization relatedOrgan in relatedOrganizations)
            {
                SuggestionRouting sugRouting = new SuggestionRouting();
                sugRouting.OrganizationID = relatedOrgan.ID;
                sugRouting.DateOfRoute = MyHelper.Now;
                sugRouting.Status = (int)MyEnums.SuggestionRoutingStatus.Pending;
                sugRouting.Visible = true;
                sug.SuggestionRoutings.Add(sugRouting);
                sug.Status = (int)MyEnums.SuggestionStatus.Routed;
            }
            if (relatedOrganizations.Count() > 0)
                sgr.Save();
            recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.CorrectSuggestion;
            /////// inform organization operators:
            if (informSetting.InformOrganizationOperators)
            {
                foreach (Organization relatedOrgan in relatedOrganizations)
                {
                    smsHelper.Send(sug.GetInformOfOrganOperators(), relatedOrgan.CellPhonesList);
                }
            }
            //******************************
            //////// response correct suggestion:
            if (setting.PersuitCodeResponse)
            {
                smsHelper.Send(setting.PersuitCodeText + "\n" + "کد رهگیری: " + sug.PersuitCode, recieved_sms.Citizen.MobNumber, true);
            }
            //////// inform routing:
            if (informSetting.InformRouting)
            {
                if (sug.SuggestionRoutings.Count() > 0)
                {
                    smsHelper.Send(sug.GetInformOfRouting(sug.SuggestionRoutings.ToList()), sug.RecievedMessage.Citizen.MobNumber, true);
                }
                else
                {
                    smsHelper.Send(sug.GetInformOfNotRouting(), sug.RecievedMessage.Citizen.MobNumber, true);
                }
            }
        }
        #endregion//
        #region PROCESS Poll Answer:
        else if (recieved_sms.Type == MyEnums.RecievedMessageType.PollAnswer)
        {
            PollsRepository pr = new PollsRepository();
            Poll activePoll = pr.GetActivePoll();
            if (activePoll != null)
            {
                int selectedOption = Int32.Parse(recieved_sms.Text);
                var pollOptions = activePoll.PollOptions.ToList();
                if (selectedOption > 0 && selectedOption <= pollOptions.Count())
                {
                    if (!activePoll.PollAnswers.Where(ans => ans.RecievedMessage.Citizen.MobNumber == recieved_sms.Citizen.MobNumber).Any())
                    {
                        PollAnswer pollAnswer = new PollAnswer();
                        pollAnswer.RecievedMessageID = recieved_sms.ID;
                        pollAnswer.SelectedOption = selectedOption;
                        activePoll.PollAnswers.Add(pollAnswer);
                        pr.Save();
                        recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.CorrectPollAnswer;
                        //////// response correct poll answer:
                        if (setting.CorrectPollAnswerResponse)
                        {
                            var sucPollingMsg = string.Format("{0}{1}{2} '{3}'", setting.CorrectPollAnswerText,
                                Environment.NewLine,
                                "نظر شما:",
                                pollOptions[selectedOption - 1].Text);
                            smsHelper.Send(sucPollingMsg, recieved_sms.Citizen.MobNumber, true);
                        }
                    }
                    else
                    {
                        var duplicateMsgText = "شما قبلا در این نظرسنجی شرکت کرده اید.";
                        smsHelper.Send(duplicateMsgText, recieved_sms.Citizen.MobNumber, true);
                    }
                }
                else
                {
                    recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.IncorrectPollOptionSelected;
                    //////// response incorrect poll option selected:
                    if (setting.IncorrectPollOptionSelectedResponse)
                    {
                        smsHelper.Send(setting.IncorrectPollOptionSelectedText, recieved_sms.Citizen.MobNumber, true);
                    }
                }
            }
            else
            {
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.NoActivePollExists;
                //////// response No Active Poll Exists:
                if (setting.NoActivePollExistResponse)
                {
                    smsHelper.Send(setting.NoActivePollExistText, recieved_sms.Citizen.MobNumber, true);
                }
            }
        }
        #endregion
        #region PROCESS Competition Answer:
        else if (recieved_sms.Type == MyEnums.RecievedMessageType.CompetitionAnswer)
        {
            CompetitionsRepository cr = new CompetitionsRepository();
            Competition activeComp = cr.GetActiveCompetition();
            if (activeComp != null)
            {
                if (activeComp.Type == (int)MyEnums.CompetitionType.Testi)
                {
                    string selectedOptionText = MyHelper.Trim(recieved_sms.CommingCompetitionAnswer);
                    if (MyHelper.IsInteger(selectedOptionText))
                    {
                        int selectedOption = Int32.Parse(selectedOptionText);
                        if (selectedOption <= activeComp.CompetitionOptions.Count())
                        {
                            CompetitionAnswer compAnswer = new CompetitionAnswer();
                            compAnswer.RecievedMessageID = recieved_sms.ID;
                            compAnswer.Answer = selectedOption.ToString();
                            activeComp.CompetitionAnswers.Add(compAnswer);
                            cr.Save();
                            recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer;
                            //////// response Correct Competition Answer:
                            if (setting.CorrectCompetitionAnswerResponse)
                            {
                                smsHelper.Send(setting.CorrectCompetitionAnswerText, recieved_sms.Citizen.MobNumber, true);
                            }
                        }
                        else
                        {
                            recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.IncorrectCompetitionOptionSelected;
                            //////// response Incorrect Competition Option Selected:
                            if (setting.IncorrectCompetitionOptionSelectedResponse)
                            {
                                smsHelper.Send(setting.IncorrectCompetitionOptionSelectedText, recieved_sms.Citizen.MobNumber, true);
                            }
                        }
                    }
                    else
                    {
                        recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.IncorrectFormat;
                        //////// response Incorrect Format:
                        if (setting.IncorrectFormatResponse)
                        {
                            smsHelper.Send(setting.IncorrectFormatText, recieved_sms.Citizen.MobNumber, true);
                        }
                    }
                }
                else
                {
                    CompetitionAnswer compAnswer = new CompetitionAnswer();
                    compAnswer.RecievedMessageID = recieved_sms.ID;
                    compAnswer.Answer = recieved_sms.CommingCompetitionAnswer;
                    activeComp.CompetitionAnswers.Add(compAnswer);
                    cr.Save();
                    recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer;
                    //////// response Correct Competition Answer:
                    if (setting.CorrectCompetitionAnswerResponse)
                    {
                        smsHelper.Send(setting.CorrectCompetitionAnswerText, recieved_sms.Citizen.MobNumber, true);
                    }
                }
            }
            else
            {
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.NoActiveCompetitionExists;
                //////// response No active Competition Exists:
                if (setting.NoActiveCompetitionExistResponse)
                {
                    smsHelper.Send(setting.NoActiveCompetitionExistText, recieved_sms.Citizen.MobNumber, true);
                }
            }
        }

        #endregion
        #region PROCESS Persuiting Suggestion:
        else if (recieved_sms.Type == MyEnums.RecievedMessageType.Persuiting)
        {
            SuggestionsRepository sgr = new SuggestionsRepository();
            Suggestion suggestion = sgr.Get(recieved_sms.Text.ToUpper());
            if (suggestion != null)
            {
                smsHelper.Send(suggestion.GetPersuitInformation(), recieved_sms.Citizen.MobNumber, true);
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.CorrectPersuitCode;
            }
            else
            {
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.IncorrectPersuitCode;
                if (setting.IncorrectPersuitCodeResponse)
                {
                    smsHelper.Send(setting.IncorrectPersuitCodeText, recieved_sms.Citizen.MobNumber, true);
                }
            }
        }
        #endregion
        #region PROCESS Service Request:
        else if (recieved_sms.Type == MyEnums.RecievedMessageType.ServiceRequest)
        {
            int serviceCode = Convert.ToInt32(recieved_sms.Text);
            if (serviceCode == ServiceCodes.Monaghesat)
            {
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.ServiceRequest;
                if (setting.MonaghesatResponse)
                {
                    smsHelper.Send(Monagheseh.ListText, recieved_sms.Citizen.MobNumber, true);
                }
                
            }
            else if (serviceCode == ServiceCodes.Mozaiedat)
            {
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.ServiceRequest;
                if (setting.MozaiedatResponse)
                {
                    smsHelper.Send(Mozaiedeh.ListText, recieved_sms.Citizen.MobNumber, true);
                }
            }
            else
            {
                recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.IncorrectServiceCode;
                if (setting.IncorrectServiceCodeResponse)
                {
                    smsHelper.Send(setting.IncorrectServiceCodeText, recieved_sms.Citizen.MobNumber, true);
                }
            }
        }
        #endregion
        #region PROCESS My Actions:
        else if (recieved_sms.Type == MyEnums.RecievedMessageType.MyAction)
        {
            string command = recieved_sms.Text.Replace("raman:", "");
            Hashtable commandInfo = MyHelper.GetHashtableFromString(command);
            string action = commandInfo["action"].ToString();
            if (action == "changestatus")
            {
                int newStatus = Convert.ToInt32(commandInfo["value"]);
                SystemInfo.Status = (MyEnums.SystemStatus)newStatus;
            }
            else if (action == "changemessage")
            {
                string message = commandInfo["value"].ToString();
                SystemInfo.ErrorMessage = message;
            }
        }
        #endregion
        #region PROCESS Incorrect format:
        else
        {
            recieved_sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.IncorrectFormat;
            //////// response Incorrect Format:
            if (setting.IncorrectFormatResponse)
            {
                smsHelper.Send(setting.IncorrectFormatText, recieved_sms.Citizen.MobNumber, true);
            }
        }
        #endregion
        ///////////////////////////////////////////////// set as Processed:
        recieved_sms.Status = (int)MyEnums.RecievedMessageStatus.Processed;
        sr.Save();
    }

    private RecievedMessage save_recieved_sms()
    {
        //System.IO.File.WriteAllText(Server.MapPath("~/Content/TempFiles/rrr.txt"), MyHelper.ToPersian(Request.QueryString["Message"].ToString()));
        MembersRepository mr = new MembersRepository();
        RecievedMessage sms = new RecievedMessage();
        string mobNumber = MyHelper.ExtractMobNumber(Request.QueryString["From"].ToString());
        sms.CitizenID = mr.FindOrCreate(mobNumber).ID;
        sms.Text = MyHelper.ToPersian(Request.QueryString["Message"].ToString());
        sms.DateOfRecieve = MyHelper.Now;
        sms.Status = (int)MyEnums.RecievedMessageStatus.New;
        sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.NotProcessed;
        ////////////////
        sms = sr.Insert(sms);
        ///////
        return sms;
    }

    private void show_errors()
    {
        SmsRepository sr = new SmsRepository();
        IEnumerable<RecievingError> errors = sr.GetErrors();
        int i = 0;
        foreach (RecievingError error in errors)
        {
            Panel error_container = new Panel();
            error_container.CssClass = "error_container";
            ////lbl:
            Label error_text = new Label();
            error_text.CssClass = "error";
            error_text.Text = ShamsiDateTime.MiladyToShamsi(error.DateOf).ToString() + " - " + error.DateOf.Hour.ToString("D2") + ":" + error.DateOf.Minute.ToString("D2") + " : " + error.Text;
            ////add:
            error_container.Controls.Add(error_text);
            pnl_errors.Controls.Add(error_container);
            i++;
        }
    }

    private void save_error(string message)
    {
        SmsRepository sr = new SmsRepository();
        RecievingError error = new RecievingError();
        error.Text = message;
        error.DateOf = MyHelper.Now;
        sr.AddError(error);
        sr.Save();
    }
}