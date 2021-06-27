using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_Settings : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cmb_SettingsType.SelectedIndex = 1;
            LoadResponseSettings();
        }
    }

    protected void cmb_SettingsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmb_SettingsType.SelectedIndex == 1)
        {
            LoadResponseSettings();
            pnl_ResponseSettings.Visible = true;
            pnl_InformSettings.Visible = false;
        }
        else if (cmb_SettingsType.SelectedIndex == 2)
        {
            LoadInformSettings();
            pnl_ResponseSettings.Visible = false;
            pnl_InformSettings.Visible = true;
        }
        else
        {
            pnl_ResponseSettings.Visible = false;
            pnl_InformSettings.Visible = false;
        }
    }

    private void LoadResponseSettings()
    {
        ResponseSetting settings = ResponseSetting.Load();
        //////// persuit code:
        ch_PersuitCode.Checked = settings.PersuitCodeResponse;
        tb_PersuitCode.Text = settings.PersuitCodeText;
        tb_PersuitCode.ReadOnly = (settings.PersuitCodeResponse ? false : true);
        tb_PersuitCode.CssClass = (settings.PersuitCodeResponse ? "textbox" : "textbox disabled_textbox");
        lbl_PersuitCode.Text = GetSmsLengthText(settings.PersuitCodeText);
        //////// Correct Poll Answer:
        ch_CorrectPollAnswer.Checked = settings.CorrectPollAnswerResponse;
        tb_CorrectPollAnswer.Text = settings.CorrectPollAnswerText;
        tb_CorrectPollAnswer.ReadOnly = (settings.CorrectPollAnswerResponse ? false : true);
        tb_CorrectPollAnswer.CssClass = (settings.CorrectPollAnswerResponse ? "textbox" : "textbox disabled_textbox");
        lbl_CorrectPollAnswer.Text = GetSmsLengthText(settings.CorrectPollAnswerText);
        //////// CorrectCompetitionAnswer:
        ch_CorrectCompetitionAnswer.Checked = settings.CorrectCompetitionAnswerResponse;
        tb_CorrectCompetitionAnswer.Text = settings.CorrectCompetitionAnswerText;
        tb_CorrectCompetitionAnswer.ReadOnly = (settings.CorrectCompetitionAnswerResponse ? false : true);
        tb_CorrectCompetitionAnswer.CssClass = (settings.CorrectCompetitionAnswerResponse ? "textbox" : "textbox disabled_textbox");
        lbl_CorrectCompetitionAnswer.Text = GetSmsLengthText(settings.CorrectCompetitionAnswerText);
        //////// IncorrectFormat:
        ch_IncorrectFormat.Checked = settings.IncorrectFormatResponse;
        tb_IncorrectFormat.Text = settings.IncorrectFormatText;
        tb_IncorrectFormat.ReadOnly = (settings.IncorrectFormatResponse ? false : true);
        tb_IncorrectFormat.CssClass = (settings.IncorrectFormatResponse ? "textbox" : "textbox disabled_textbox");
        lbl_IncorrectFormat.Text = GetSmsLengthText(settings.IncorrectFormatText);
        //////// IncorrectPollOptionSelected:
        ch_IncorrectPollOptionSelected.Checked = settings.IncorrectPollOptionSelectedResponse;
        tb_IncorrectPollOptionSelected.Text = settings.IncorrectPollOptionSelectedText;
        tb_IncorrectPollOptionSelected.ReadOnly = (settings.IncorrectPollOptionSelectedResponse ? false : true);
        tb_IncorrectPollOptionSelected.CssClass = (settings.IncorrectPollOptionSelectedResponse ? "textbox" : "textbox disabled_textbox");
        lbl_IncorrectPollOptionSelected.Text = GetSmsLengthText(settings.IncorrectPollOptionSelectedText);
        //////// IncorrectCompetitionOptionSelected:
        ch_IncorrectCompetitionOptionSelected.Checked = settings.IncorrectCompetitionOptionSelectedResponse;
        tb_IncorrectCompetitionOptionSelected.Text = settings.IncorrectCompetitionOptionSelectedText;
        tb_IncorrectCompetitionOptionSelected.ReadOnly = (settings.IncorrectCompetitionOptionSelectedResponse ? false : true);
        tb_IncorrectCompetitionOptionSelected.CssClass = (settings.IncorrectCompetitionOptionSelectedResponse ? "textbox" : "textbox disabled_textbox");
        lbl_IncorrectCompetitionOptionSelected.Text = GetSmsLengthText(settings.IncorrectCompetitionOptionSelectedText);
        //////// NoActivePollExist:
        ch_NoActivePollExist.Checked = settings.NoActivePollExistResponse;
        tb_NoActivePollExist.Text = settings.NoActivePollExistText;
        tb_NoActivePollExist.ReadOnly = (settings.NoActivePollExistResponse ? false : true);
        tb_NoActivePollExist.CssClass = (settings.NoActivePollExistResponse ? "textbox" : "textbox disabled_textbox");
        lbl_NoActivePollExist.Text = GetSmsLengthText(settings.NoActivePollExistText);
        //////// NoActiveCompetitionExist:
        ch_NoActiveCompetitionExist.Checked = settings.NoActiveCompetitionExistResponse;
        tb_NoActiveCompetitionExist.Text = settings.NoActiveCompetitionExistText;
        tb_NoActiveCompetitionExist.ReadOnly = (settings.NoActiveCompetitionExistResponse ? false : true);
        tb_NoActiveCompetitionExist.CssClass = (settings.NoActiveCompetitionExistResponse ? "textbox" : "textbox disabled_textbox");
        lbl_NoActiveCompetitionExist.Text = GetSmsLengthText(settings.NoActiveCompetitionExistText);
        //////// IncorrectPersuitCode:
        ch_IncorrectPersuitCode.Checked = settings.IncorrectPersuitCodeResponse;
        tb_IncorrectPersuitCode.Text = settings.IncorrectPersuitCodeText;
        tb_IncorrectPersuitCode.ReadOnly = (settings.IncorrectPersuitCodeResponse ? false : true);
        tb_IncorrectPersuitCode.CssClass = (settings.IncorrectPersuitCodeResponse ? "textbox" : "textbox disabled_textbox");
        lbl_IncorrectPersuitCode.Text = GetSmsLengthText(settings.IncorrectPersuitCodeText);
        //////// Monaghesat:
        ch_Monaghesat.Checked = settings.MonaghesatResponse;
        tb_Monaghesat.Text = settings.MonaghesatPattern;
        tb_Monaghesat.ReadOnly = (settings.MonaghesatResponse ? false : true);
        tb_Monaghesat.CssClass = (settings.MonaghesatResponse ? "textbox" : "textbox disabled_textbox");
        //////// Mozaiedat:
        ch_Mozaiedat.Checked = settings.MozaiedatResponse;
        tb_Mozaiedat.Text = settings.MozaiedatPattern;
        tb_Mozaiedat.ReadOnly = (settings.MozaiedatResponse ? false : true);
        tb_Mozaiedat.CssClass = (settings.MozaiedatResponse ? "textbox" : "textbox disabled_textbox");
        //////// IncorrectServiceCode:
        ch_IncorrectServiceCode.Checked = settings.IncorrectServiceCodeResponse;
        tb_IncorrectServiceCode.Text = settings.IncorrectServiceCodeText;
        tb_IncorrectServiceCode.ReadOnly = (settings.IncorrectServiceCodeResponse ? false : true);
        tb_IncorrectServiceCode.CssClass = (settings.IncorrectServiceCodeResponse ? "textbox" : "textbox disabled_textbox");
        lbl_IncorrectServiceCode.Text = GetSmsLengthText(settings.IncorrectServiceCodeText);
    }

    private void LoadInformSettings()
    {
        InformSetting setting = InformSetting.Load();
        ch_InformRouting.Checked = setting.InformRouting;
        ch_InformRejection.Checked = setting.InformRejection;
        ch_InformVerifying.Checked = setting.InformVerifying;
        ch_InformOrganizationOperators.Checked = setting.InformOrganizationOperators;
    }

    private string GetSmsLengthText(string smsText)
    {
        string info = "";
        int sms_count = (int)(smsText.Length / 70) + (smsText.Length % 70 == 0 ? 0 : 1);
        info = smsText.Length + "/" + sms_count;
        return info;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            ResponseSetting setting = new ResponseSetting();
            setting.ID = 1;
            //************** PersuitCode:
            setting.PersuitCodeResponse = ch_PersuitCode.Checked;
            setting.PersuitCodeText = tb_PersuitCode.Text;
            //************** CorrectPollAnswer:
            setting.CorrectPollAnswerResponse = ch_CorrectPollAnswer.Checked;
            setting.CorrectPollAnswerText = tb_CorrectPollAnswer.Text;
            //************** CorrectCompetitionAnswer:
            setting.CorrectCompetitionAnswerResponse = ch_CorrectCompetitionAnswer.Checked;
            setting.CorrectCompetitionAnswerText = tb_CorrectCompetitionAnswer.Text;
            //************** IncorrectFormat:
            setting.IncorrectFormatResponse = ch_IncorrectFormat.Checked;
            setting.IncorrectFormatText = tb_IncorrectFormat.Text;
            //************** IncorrectPollOptionSelected:
            setting.IncorrectPollOptionSelectedResponse = ch_IncorrectPollOptionSelected.Checked;
            setting.IncorrectPollOptionSelectedText = tb_IncorrectPollOptionSelected.Text;
            //************** IncorrectCompetitionOptionSelected:
            setting.IncorrectCompetitionOptionSelectedResponse = ch_IncorrectCompetitionOptionSelected.Checked;
            setting.IncorrectCompetitionOptionSelectedText = tb_IncorrectCompetitionOptionSelected.Text;
            //************** NoActivePollExist:
            setting.NoActivePollExistResponse = ch_NoActivePollExist.Checked;
            setting.NoActivePollExistText = tb_NoActivePollExist.Text;
            //************** NoActiveCompetitionExist:
            setting.NoActiveCompetitionExistResponse = ch_NoActiveCompetitionExist.Checked;
            setting.NoActiveCompetitionExistText = tb_NoActiveCompetitionExist.Text;
            //************** IncorrectPersuitCode:
            setting.IncorrectPersuitCodeResponse = ch_IncorrectPersuitCode.Checked;
            setting.IncorrectPersuitCodeText = tb_IncorrectPersuitCode.Text;
            //************** Monaghesat:
            setting.MonaghesatResponse = ch_Monaghesat.Checked;
            setting.MonaghesatPattern = tb_Monaghesat.Text;
            //************** Mozaiedat:
            setting.MozaiedatResponse = ch_Mozaiedat.Checked;
            setting.MozaiedatPattern = tb_Mozaiedat.Text;
            //************** IncorrectServiceCode:
            setting.IncorrectServiceCodeResponse = ch_IncorrectServiceCode.Checked;
            setting.IncorrectServiceCodeText = tb_IncorrectServiceCode.Text;
            //************** Save:
            ResponseSetting.Save(setting);
            //************** Show messages:
            lbl_messageOfresponseSettings.Text = "با موفقیت انجام شد.";
            msg_responseSettings.CssClass = "center succeed";
            msg_responseSettings.Visible = true;
            up_response_message.Update();
        }
        catch(Exception ex)
        {
            lbl_messageOfresponseSettings.Text = ex.Message;
            msg_responseSettings.CssClass = "center failed";
            msg_responseSettings.Visible = true;
            up_response_message.Update();
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            InformSetting setting = new InformSetting();
            setting.InformRouting = ch_InformRouting.Checked;
            setting.InformRejection = ch_InformRejection.Checked;
            setting.InformVerifying = ch_InformVerifying.Checked;
            setting.InformOrganizationOperators = ch_InformOrganizationOperators.Checked;
            InformSetting.Save(setting);
            ////////////////////////////////
            lbl_message_inform_settings.Text = "با موفقیت انجام شد";
            pnl_message_inform_settings.CssClass = "center succeed";
            pnl_message_inform_settings.Visible = true;
            up_message_inform_settings.Update();
        }
        catch (Exception ex)
        {
            lbl_message_inform_settings.Text = ex.Message;
            pnl_message_inform_settings.CssClass = "center failed";
            pnl_message_inform_settings.Visible = true;
            up_message_inform_settings.Update();
        }
    }
}