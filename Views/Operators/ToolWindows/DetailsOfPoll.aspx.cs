using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ToolWindows_DetailsOfPoll : System.Web.UI.Page
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
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}