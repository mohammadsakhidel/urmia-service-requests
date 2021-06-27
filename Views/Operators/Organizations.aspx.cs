using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Models;
using Controllers;
using System.Web.Security;

public partial class Views_Operators_Organizations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Permissions.UsersViewPermission)
                    uc_Organizations.LoadAll();
                else
                    uc_Organizations.Visible = false;
            }
            catch (Exception exc)
            {
                MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
            }
        }
    }
}