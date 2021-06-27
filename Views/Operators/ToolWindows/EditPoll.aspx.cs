using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ToolWindows_NewPoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                PollsRepository pr = new PollsRepository();
                Poll poll = pr.Get(Id);
                uc_Poll.Poll = poll;
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (uc_Poll.DaysOfActivity > 0)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                PollsRepository pr = new PollsRepository();
                ///// poll info:
                Poll poll = pr.Get(Id);
                poll.Subject = uc_Poll.Subject;
                poll.Text = uc_Poll.Text;
                poll.DaysOfActivity = uc_Poll.DaysOfActivity;
                ///// options:
                pr.DeleteOptions(poll.PollOptions.ToList());
                int i = 1;
                foreach (string option in uc_Poll.Options)
                {
                    PollOption pollOption = new PollOption();
                    pollOption.Text = option;
                    pollOption.Identifier = i;
                    poll.PollOptions.Add(pollOption);
                    i++;
                }
                ///// save:
                pr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
            else
            {
                throw new Exception("مدت اعتبار را بصورت عدد وارد نمایید");
            }
        }
        catch(Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}