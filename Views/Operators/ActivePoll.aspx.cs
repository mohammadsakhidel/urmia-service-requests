using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ActivePoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Permissions.PollsViewPermission)
                {
                    PollsRepository pr = new PollsRepository();
                    Poll activePoll = pr.GetActivePoll();
                    uc_ActivePoll.Poll = activePoll;
                }
                else
                {
                    uc_ActivePoll.Visible = false;
                }
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}