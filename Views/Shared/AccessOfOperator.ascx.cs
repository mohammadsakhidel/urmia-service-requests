using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_AccessOfOperator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int OperatorID
    {
        get
        {
            return ViewState["OperatorID"] != null ? Convert.ToInt32(ViewState["OperatorID"]) : 0;
        }
        set
        {
            ViewState["OperatorID"] = value;
        }
    }

    public OperatorAccessRule OperatorAccessRule
    {
        get
        {
            return null;
        }
        set
        {
            cmb_Users.SelectedIndex = value.Users - 1;
            cmb_Suggestions.SelectedIndex = value.Suggestions - 1;
            cmb_Polls.SelectedIndex = value.Polls - 1;
            cmb_Competitions.SelectedIndex = value.Competitions - 1;
            cmb_SendSms.SelectedIndex = value.SendSms - 1;
            cmb_Reports.SelectedIndex = value.Reports - 1;
            cmb_Services.SelectedIndex = value.Services - 1;
            cmb_Settings.SelectedIndex = value.Settings - 1;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            OperatorAccessRule rule = new OperatorAccessRule();
            rule.Users = Convert.ToInt32(cmb_Users.SelectedValue);
            rule.Suggestions = Convert.ToInt32(cmb_Suggestions.SelectedValue);
            rule.Polls = Convert.ToInt32(cmb_Polls.SelectedValue);
            rule.Competitions = Convert.ToInt32(cmb_Competitions.SelectedValue);
            rule.SendSms = Convert.ToInt32(cmb_SendSms.SelectedValue);
            rule.Reports = Convert.ToInt32(cmb_Reports.SelectedValue);
            rule.Services = Convert.ToInt32(cmb_Services.SelectedValue);
            rule.Settings = Convert.ToInt32(cmb_Settings.SelectedValue);
            ///////SAVE:
            MembersRepository mr = new MembersRepository();
            Operator op = mr.GetOperator(OperatorID);
            op.OperatorAccessRule = rule;
            mr.Save();
            ///////
            MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}