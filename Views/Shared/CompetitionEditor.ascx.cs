using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_CompetitionEditor : System.Web.UI.UserControl
{
    Competition competition = new Competition();
    //*******************************************************
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Competition Competition
    {
        set
        {
            competition = value;
            tb_Subject.Text = value.Subject;
            tb_Text.Text = value.SmsText;
            tb_Days.Text = value.DaysOfActivity.ToString();
            cmb_Type.SelectedIndex = value.Type;
            uc_Options.Keywords = value.CompetitionOptions.Select(option => option.Text).ToList();
        }
    }
    public string Subject
    {
        get
        {
            return tb_Subject.Text;
        }
    }
    public string SmsText
    {
        get
        {
            return tb_Text.Text;
        }
    }
    public int DaysOfActivity
    {
        get
        {
            return (MyHelper.IsInteger(tb_Days.Text) ? Int32.Parse(tb_Days.Text) : 0);
        }
    }
    public MyEnums.CompetitionType Type
    {
        get
        {
            return (MyEnums.CompetitionType)cmb_Type.SelectedIndex;
        }
    }
    public List<string> Options
    {
        get
        {
            return uc_Options.Keywords;
        }
    }
}