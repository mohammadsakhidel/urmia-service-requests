using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Shared_PasswordChange : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string UserName
    {
        get
        {
            return (ViewState["UserName"] != null ? ViewState["UserName"].ToString() : "");
        }
        set
        {
            ViewState["UserName"] = value;
            lbl_UserNumber.Text = value;
            MembershipUser user = Membership.GetUser(value);
            string pass = user.GetPassword();
            tb_Password.Attributes["value"] = pass;
            tb_Confirm.Attributes["value"] = pass;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser user = Membership.GetUser(UserName);
            string oldPassword = user.GetPassword();
            string newPassword = tb_Password.Text;
            user.ChangePassword(oldPassword, newPassword);
            Membership.UpdateUser(user);
            MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}