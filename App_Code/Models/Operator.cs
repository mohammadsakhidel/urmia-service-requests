using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Operator
/// </summary>
namespace Models
{
    public partial class Operator
    {
        public static Operator CurrentUser
        {
            get
            {
                MembersRepository mr = new MembersRepository();
                return mr.GetOperator(HttpContext.Current.User.Identity.Name);
            }
        }

        public string DateOfCreateText
        {
            get
            {
                return Controllers.ShamsiDateTime.MiladyToShamsi(this.DateOfCreate).ToMediumString();
            }
        }

        public string HtmlOfEditButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditOperator.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 600, 300);\"></a>";
            }
        }

        public bool IsApproved
        {
            get
            {
                return System.Web.Security.Membership.GetUser(this.UserName).IsApproved;
            }
        }

        public string HtmlOfAccessRule
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/AccessOfOperator.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_access\" title=\"سطح دسترسی\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 550, 600);\"></a>";
            }
        }

        public OperatorAccessRule GetOperatorAccessRule()
        {
            return this.OperatorAccessRule != null ? this.OperatorAccessRule : OperatorAccessRule.Default;
        }
    }
}