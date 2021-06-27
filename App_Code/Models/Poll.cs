using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Poll
/// </summary>
namespace Models
{
    public partial class Poll
    {
        public string CutedSubject
        {
            get
            {
                return "<span title=\""+ this.Text +"\">"+ MyHelper.CutString(this.Subject, 20) +"</span>";
            }
        }

        public string DateOfCreateText
        {
            get
            {
                return Controllers.ShamsiDateTime.MiladyToShamsi(this.DateOfCreate).ToString() + " - " + this.DateOfCreate.Hour.ToString() + ":" + this.DateOfCreate.Minute.ToString();
            }
        }

        public DateTime DateOfExpire
        {
            get
            {
                return this.DateOfCreate.AddDays(this.DaysOfActivity);
            }
        }

        public string DateOfExpireText
        {
            get
            {
                return Controllers.ShamsiDateTime.MiladyToShamsi(this.DateOfExpire).ToString() + " - " + this.DateOfCreate.Hour.ToString() + ":" + this.DateOfCreate.Minute.ToString();
            }
        }

        public string DaysOfActivityText
        {
            get
            {
                return DaysOfActivity + " روز";
            }
        }

        public string HtmlOfEditButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditPoll.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 700, 450);\"></a>";
            }
        }

        public string HtmlOfDetailsButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfPoll.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_details\" title=\"جزئیات\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 700, 500);\"></a>";
            }
        }

        public string HtmlOfSendButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/SendPoll.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_send\" title=\"ارسال\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 780, 520);\"></a>";
            }
        }
        
    }
}