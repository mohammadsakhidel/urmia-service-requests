using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.Security;

public partial class Views_Shared_OrganEditor : System.Web.UI.UserControl
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

    public int OrganizationID
    {
        get
        {
            return (ViewState["OrganizationID"] != null ? Convert.ToInt32(ViewState["OrganizationID"]) : -1);
        }
        set
        {
            ViewState["OrganizationID"] = value;
            ///////////
            MembersRepository mr = new MembersRepository();
            Organization organ = mr.GetOrganization(value);
            MembershipUser user = Membership.GetUser(organ.UserName);
            ////////////
            string password = user.GetPassword();
            tb_Name.Text = organ.Name;
            tb_UserName.Text = organ.UserName;
            tb_Password.Attributes["value"] = password;
            tb_PasswordConfirm.Attributes["value"] = password;
            tb_CellPhones.Text = organ.CellPhones;
            ch_ViewUnroutedSuggestions.Checked = organ.ViewUnroutedSuggestions;
            uc_Keywords.Keywords = organ.OrganizationKeywords.Select(key => key.Text).ToList();
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
                    Organization organ = new Organization();
                    organ.Name = tb_Name.Text;
                    organ.UserName = tb_UserName.Text;
                    organ.ViewUnroutedSuggestions = ch_ViewUnroutedSuggestions.Checked;
                    organ.DateOfCreate = MyHelper.Now;
                    organ.CreatedBy = HttpContext.Current.User.Identity.Name;
                    if (tb_CellPhones.Text.Trim().Length > 0) organ.CellPhones = tb_CellPhones.Text;
                    ///// add keywords:
                    List<string> keywords = uc_Keywords.Keywords;
                    foreach (string keyword in keywords)
                    {
                        OrganizationKeyword organKey = new OrganizationKeyword();
                        organKey.Text = MyHelper.ToPersian(keyword);
                        organ.OrganizationKeywords.Add(organKey);
                    }
                    ///// membership user:
                    MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                    if (newUser != null)
                    {
                        /////add to role:
                        Roles.AddUserToRole(newUser.UserName, MyRoles.Organization);
                        Membership.UpdateUser(newUser);
                        /////save in db:
                        MembersRepository mr = new MembersRepository();
                        mr.AddOrganization(organ);
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
                    int Id = OrganizationID;
                    MembersRepository mr = new MembersRepository();
                    ///// organ object:
                    Organization organ = mr.GetOrganization(Id);
                    string oldUserName = organ.UserName;
                    bool oldApproved = organ.IsApproved;
                    organ.Name = tb_Name.Text;
                    organ.UserName = tb_UserName.Text;
                    organ.ViewUnroutedSuggestions = ch_ViewUnroutedSuggestions.Checked;
                    if (tb_CellPhones.Text.Trim().Length > 0)
                        organ.CellPhones = tb_CellPhones.Text;
                    else
                        organ.CellPhones = null;
                    ///// add keywords:
                    mr.DeleteKeywords(organ.OrganizationKeywords.ToList());
                    List<string> keywords = uc_Keywords.Keywords;
                    foreach (string keyword in keywords)
                    {
                        OrganizationKeyword organKey = new OrganizationKeyword();
                        organKey.Text = MyHelper.ToPersian(keyword);
                        organ.OrganizationKeywords.Add(organKey);
                    }
                    ///// membership user:
                    Membership.DeleteUser(oldUserName, true);
                    MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                    if (newUser != null)
                    {
                        /////add to role:
                        newUser.IsApproved = oldApproved;
                        Roles.AddUserToRole(newUser.UserName, MyRoles.Organization);
                        Membership.UpdateUser(newUser);
                        /////save in db:
                        mr.Save();
                        MyHelper.MessageBoxShow("با موفقیت ذخیره شد", (LinkButton)sender, typeof(LinkButton));
                    }
                    else
                    {
                        throw new Exception("خطا در تصحیح حساب کاربری");
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