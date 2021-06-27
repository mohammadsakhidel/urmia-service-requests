using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Mayor_AcountSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                uc_PasswordChange.UserName = User.Identity.Name;
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}