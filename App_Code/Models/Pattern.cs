using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Controllers;

namespace Models
{
    public partial class Pattern
    {
        public string DateOfCreateText
        {
            get
            {
                return MyHelper.DateToText(this.DateOfCreate, MyEnums.DateType.MediumWithTime);
            }
        }

        public string HtmlOfGridActions
        {
            get
            {
                string url_edit = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditPattern.aspx") + "?Id=" + this.ID.ToString();
                string url_send = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/SendPattern.aspx") + "?Id=" + this.ID.ToString();
                string html =
                    (Permissions.SendSmsWritePermission ? 
                    "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url_edit + "\" onclick=\"return Open('" + url_edit + "', '', 600, 350);\"></a>" +
                    "<a class=\"grid_button grid_send\" title=\"ارسال\" href=\"" + url_send + "\" onclick=\"return Open('" + url_send + "', '', 780, 520);\" style=\"margin-right : 5px;\"></a>" 
                    : "");
                return html;
            }
        }
    }
}