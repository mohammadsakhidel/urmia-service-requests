using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_PollEditor : System.Web.UI.UserControl
{
    Poll poll = new Poll();
    //*******************************
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public Poll Poll {
        set
        {
            poll = value;
            tb_Subject.Text = value.Subject;
            tb_Text.Text = value.Text;
            tb_Days.Text = value.DaysOfActivity.ToString();
            uc_Options.Keywords = value.PollOptions.Select(option => option.Text).ToList();
        }
    }
    public string Subject
    {
        get
        {
            return tb_Subject.Text;
        }
    }
    public string Text
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
    public List<string> Options
    {
        get
        {
            return uc_Options.Keywords;
        }
    }
}