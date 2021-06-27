using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.Security;

public partial class Views_Operators_Operators : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Operator op = new Operator();
                if (Permissions.UsersViewPermission)
                    uc_Operators.LoadAll();
                else
                    uc_Operators.Visible = false;
            }
            catch (Exception exc)
            {
                MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
            }
        }
    }

}