using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MembersRepository mr = new MembersRepository();
            List<Organization> organs = mr.GetAllOrganizations().OrderBy(o => o.Name).ToList();
            cmb_Organ.Items.Add(new ListItem("واحد مورد نظر خود را انتخاب کنید (اختیاری)", ""));
            foreach (Organization organ in organs)
            {
                cmb_Organ.Items.Add(new ListItem(organ.Name, organ.ID.ToString()));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var name = tb_Name.Text;
        var mob_num = tb_MobNumber.Text;
        var text = tb_RequestText.Text;
        int? organId = (cmb_Organ.SelectedIndex > 0 ? Convert.ToInt32(cmb_Organ.SelectedValue) : (int?)null);

        #region Validate inputs and process:
        var is_name_valid = !String.IsNullOrEmpty(name);
        var is_mob_valid = !String.IsNullOrEmpty(mob_num) && MyHelper.IsValidMobNumber(mob_num);
        var is_valid_text = !String.IsNullOrEmpty(text) && RecievedMessage.IsSuggestion(text);
        if (is_name_valid && is_mob_valid && is_valid_text)
        {
            var sms = save_recieved_sms(text, mob_num, name);
            process_recieved_sms(sms, organId);

            #region Update Form Values:
            tb_Name.Text = "";
            tb_MobNumber.Text = "";
            tb_RequestText.Text = "";
            cmb_Organ.SelectedIndex = 0;

            lblErrorMessage.Text = "";
            lblSuccessMessage.Text = "با موفقیت ارسال شد. بزودی کد رهگیری برای شما پیامک خواهد شد.";
            lblErrorMessage.Visible = false;
            lblSuccessMessage.Visible = true;
            #endregion
        }
        else
        {
            var err_text = "";
            if (!is_name_valid)
                err_text += "لطفاً نام و نام خانوادگی خود را وارد فرمایید.";
            if (!is_mob_valid)
                err_text += (String.IsNullOrEmpty(err_text) ? "" : "<br />") + "لطفاً شماره همراه خود را بصورت صحیح وارد فرمایید.";
            if (!is_valid_text)
                err_text += (String.IsNullOrEmpty(err_text) ? "" : "<br />") + "شرح درخواست وارد شده معتبر نیست، لطفاً دوباره تلاش کنید.";

            #region Update Form Values:
            lblErrorMessage.Text = err_text;
            lblSuccessMessage.Text = "";
            lblErrorMessage.Visible = true;
            lblSuccessMessage.Visible = false;
            #endregion
        }
        #endregion
    }

    #region SEND REQUEST CODES:
    private RecievedMessage save_recieved_sms(string text, string mobile, string citizen_name)
    {
        SmsRepository sr = new SmsRepository();
        MembersRepository mr = new MembersRepository();
        RecievedMessage sms = new RecievedMessage();
        string mobNumber = MyHelper.ExtractMobNumber(mobile);
        var citizen = mr.FindOrCreate(mobNumber, citizen_name);
        sms.CitizenID = citizen.ID;
        sms.Text = text;
        sms.DateOfRecieve = MyHelper.Now;
        sms.Status = (int)MyEnums.RecievedMessageStatus.New;
        sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.FromService;
        ////////////////
        sms = sr.Insert(sms);
        ///////
        return sms;
    }
    private void process_recieved_sms(RecievedMessage recieved_sms, int? organId)
    {
        SmsHelper smsHelper = new SmsHelper();
        ResponseSetting setting = ResponseSetting.Load();
        InformSetting informSetting = InformSetting.Load();
        SuggestionsRepository sgr = new SuggestionsRepository();
        MembersRepository mr = new MembersRepository();

        #region SAVE SUGGESTION:
        Suggestion sug = new Suggestion();
        sug.RecievedMessageID = recieved_sms.ID;
        sug.Status = (int)MyEnums.SuggestionStatus.NotRouted;
        sug.PersuitCode = sgr.GetNewPersuitCode();
        sug.Visible = true;
        sug = sgr.Insert(sug);
        #endregion

        #region ROUTING:
        List<Organization> relatedOrganizations = (organId.HasValue ? new List<Organization>() { mr.GetOrganization(organId.Value) } : sgr.GetRelatedOrganizations(sug));
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
        #endregion

        #region FEEDBACK:
        /////// inform organization operators:
        if (informSetting != null && informSetting.InformOrganizationOperators)
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
        #endregion
    }
    #endregion
}