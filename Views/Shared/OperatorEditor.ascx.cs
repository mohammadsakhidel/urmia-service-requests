using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.Security;

public partial class Views_Shared_OperatorEditor : System.Web.UI.UserControl
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

    public int OperatorID
    {
        get
        {
            return (ViewState["OperatorID"] != null ? Convert.ToInt32(ViewState["OperatorID"]) : -1);
        }
        set
        {
            ViewState["OperatorID"] = value;
            ///////////
            MembersRepository mr = new MembersRepository();
            Operator op = mr.GetOperator(value);
            MembershipUser user = Membership.GetUser(op.UserName);
            ////////////
            string password = user.GetPassword();
            tb_Name.Text = op.Name;
            tb_UserName.Text = op.UserName;
            tb_Password.Attributes["value"] = password;
            tb_PasswordConfirm.Attributes["value"] = password;
        }
    }
    //******************************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
                    Operator op = new Operator();
                    op.Name = tb_Name.Text;
                    op.UserName = tb_UserName.Text;
                    op.DateOfCreate = MyHelper.Now;
                    op.CreatedBy = MyHelper.User.Identity.Name;
                    ///// membership user:
                    MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                    if (newUser != null)
                    {
                        /////add to role:
                        Roles.AddUserToRole(newUser.UserName, MyRoles.Operator);
                        Membership.UpdateUser(newUser);
                        /////save in db:
                        MembersRepository mr = new MembersRepository();
                        mr.AddOperator(op);
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
                    ///// operator object:
                    int Id = OperatorID;
                    MembersRepository mr = new MembersRepository();
                    Operator op = mr.GetOperator(Id);
                    string oldUserName = op.UserName;
                    bool oldApproved = op.IsApproved;
                    op.Name = tb_Name.Text;
                    op.UserName = tb_UserName.Text;
                    ///// membership user:
                    Membership.DeleteUser(oldUserName, true);
                    MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                    if (newUser != null)
                    {
                        /////add to role:
                        newUser.IsApproved = oldApproved;
                        Roles.AddUserToRole(newUser.UserName, MyRoles.Operator);
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