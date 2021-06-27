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
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (uc_Poll.DaysOfActivity > 0)
            {
                ///// poll info:
                Poll poll = new Poll();
                poll.Subject = uc_Poll.Subject;
                poll.Text = uc_Poll.Text;
                poll.DaysOfActivity = uc_Poll.DaysOfActivity;
                poll.DateOfCreate = MyHelper.Now;
                poll.CreatedBy = User.Identity.Name;
                ///// options:
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
                PollsRepository pr = new PollsRepository();
                pr.Add(poll);
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