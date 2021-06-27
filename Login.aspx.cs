using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Login : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.Form.DefaultButton = Login1.FindControl("LoginButton").UniqueID;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (MyHelper.IsUserAuthenticated)
            {
                Response.Redirect("~/Views/" + MyRoles.FolderName + "/Panel.aspx");
            }
        }
        catch
        {
        }
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Login1.UserName, MyRoles.Administrator))
        {
            Response.Redirect("~/Views/Admins/Panel.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, MyRoles.Operator))
        {
            Response.Redirect("~/Views/Operators/Panel.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, MyRoles.Organization))
        {
            Response.Redirect("~/Views/Organizations/Panel.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, MyRoles.Supervisor))
        {
            Response.Redirect("~/Views/Supervisors/Panel.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, MyRoles.Mayor))
        {
            Response.Redirect("~/Views/Mayor/Panel.aspx");
        }
    }
}