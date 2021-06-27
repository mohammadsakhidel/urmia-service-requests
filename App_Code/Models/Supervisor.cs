using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Supervisor
/// </summary>
namespace Models
{
    public partial class Supervisor
    {
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
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditSupervisor.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 600, 350);\"></a>";
            }
        }

        public bool IsApproved
        {
            get
            {
                return System.Web.Security.Membership.GetUser(this.UserName).IsApproved;
            }
        }
    }
}