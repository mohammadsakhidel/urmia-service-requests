using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Masters_SupervisorPanel : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginStatus2_LoggedOut(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
