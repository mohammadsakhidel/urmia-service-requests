using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Operators_Citizens : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Permissions.UsersViewPermission)
                    uc_Citizens.Visible = true;
                else
                    uc_Citizens.Visible = false;
            }
            catch (Exception exc)
            {
                MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
            }
        }
    }

    
}