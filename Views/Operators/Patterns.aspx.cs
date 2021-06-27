using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Operators_Patterns : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Permissions.SendSmsViewPermission)
                {
                    uc_Patterns.LoadPatterns();
                }
                else
                {
                    uc_Patterns.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
            }
        }
    }
}