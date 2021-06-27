using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Masters_Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MyEnums.SystemStatus sysStatus = SystemInfo.Status;
            if (sysStatus == MyEnums.SystemStatus.Stoped)
            {
                Response.Redirect("~/Views/Shared/Error.aspx");
            }
            else if (sysStatus == MyEnums.SystemStatus.RunningWithError)
            {
                string errorMessage = SystemInfo.ErrorMessage;
                throw new Exception(errorMessage);
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}
