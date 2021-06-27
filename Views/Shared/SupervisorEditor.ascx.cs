using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.Security;

public partial class Views_Shared_SupervisorEditor : System.Web.UI.UserControl
{
    //****************************************************** PROPERTIES:
    public string Action
    {
        get
        {
            return (ViewState["Action"] != null ? ViewState["Action"].ToString() : "create");
        }
        set
        {
            ViewState["Action"] = value;
        }
    }

    public int SupervisorID
    {
        get
        {
            return (ViewState["SupervisorID"] != null ? Convert.ToInt32(ViewState["SupervisorID"]) : -1);
        }
        set
        {
            ViewState["SupervisorID"] = value;
            ///////////
            int Id = SupervisorID;
            MembersRepository mr = new MembersRepository();
            Supervisor sup = mr.GetSupervisor(Id);
            MembershipUser user = Membership.GetUser(sup.UserName);
            ////////////
            string password = user.GetPassword();
            tb_Name.Text = sup.Name;
            tb_Position.Text = sup.Position;
            tb_UserName.Text = sup.UserName;
            tb_Password.Attributes["value"] = password;
            tb_PasswordConfirm.Attributes["value"] = password;
        }
    }
    //******************************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            tb_Name.Focus();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Action == "create")
            {
                if (MyHelper.IsCorrectUserName(tb_UserName.Text) && MyHelper.IsCorrectPassword(tb_Password.Text))
                {
                    ///// organ object:
                    Supervisor sup = new Supervisor();
                    sup.Name = tb_Name.Text;
                    sup.Position = tb_Position.Text;
                    sup.UserName = tb_UserName.Text;
                    sup.DateOfCreate = MyHelper.Now;
                    sup.CreatedBy = MyHelper.User.Identity.Name;
                    ///// membership user:
                    MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                    if (newUser != null)
                    {
                        /////add to role:
                        Roles.AddUserToRole(newUser.UserName, MyRoles.Supervisor);
                        Membership.UpdateUser(newUser);
                        /////save in db:
                        MembersRepository mr = new MembersRepository();
                        mr.AddSupervisor(sup);
                        mr.Save();
                        MyHelper.MessageBoxShow("با موفقیت ذخیره شد", (LinkButton)sender, typeof(LinkButton));
                    }
                    else
                    {
                        throw new Exception("خطا در ایجاد حساب کاربری");
                    }
                }
                else
                {
                    throw new Exception("نام کاربری یا کلمه رمز فاقد اعتبار است");
                }
            }
            else if (Action == "edit")
            {
                if (MyHelper.IsCorrectUserName(tb_UserName.Text) && MyHelper.IsCorrectPassword(tb_Password.Text))
                {
                    MembersRepository mr = new MembersRepository();
                    int Id = SupervisorID;
                    ///// organ object:
                    Supervisor sup = mr.GetSupervisor(Id);
                    string oldUserName = sup.UserName;
                    bool oldApproved = sup.IsApproved;
                    sup.Name = tb_Name.Text;
                    sup.Position = tb_Position.Text;
                    sup.UserName = tb_UserName.Text;
                    ///// membership user:
                    Membership.DeleteUser(oldUserName, true);
                    MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                    if (newUser != null)
                    {
                        /////add to role:
                        Roles.AddUserToRole(newUser.UserName, MyRoles.Supervisor);
                        newUser.IsApproved = oldApproved;
                        Membership.UpdateUser(newUser);
                        /////save in db:
                        mr.Save();
                        MyHelper.MessageBoxShow("با موفقیت ذخیره شد", (LinkButton)sender, typeof(LinkButton));
                    }
                    else
                    {
                        throw new Exception("خطا در ایجاد حساب کاربری");
                    }
                }
                else
                {
                    throw new Exception("نام کاربری یا کلمه رمز فاقد اعتبار است");
                }
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)sender, typeof(LinkButton));
        }
    }
}