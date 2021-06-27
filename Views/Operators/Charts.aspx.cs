using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Operators_Charts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (!Permissions.ReportsViewPermission)
                {
                    uc_Charts.Visible = false;
                }
            }
            catch (Exception exc)
            {
                MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
            }
        }
    }
}