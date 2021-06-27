using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Competition
/// </summary>
namespace Models
{
    public partial class Competition
    {
        public string TypeText
        {
            get
            {
                string text = "";
                if (this.Type == (int)MyEnums.CompetitionType.Testi)
                    text = "چند گزینه ای";
                else if (this.Type == (int)MyEnums.CompetitionType.Tashrihi)
                    text = "تشریحی";
                return text;
            }
        }

        public string CutedSubject
        {
            get
            {
                return "<span title=\"" + this.SmsText + "\">" + MyHelper.CutString(this.Subject, 20) + "</span>";
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
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditCompetition.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 700, 450);\"></a>";
            }
        }

        public string HtmlOfDetailsButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfCompetition.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_details\" href=\"" + url + "\" title=\"جزئیات\" onclick=\"return Open('" + url + "', '', 700, 500);\"></a>";
            }
        }

        public string HtmlOfSendButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/SendCompetition.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_send\" href=\"" + url + "\" title=\"ارسال\" onclick=\"return Open('" + url + "', '', 780, 520);\"></a>";
            }
        }
    }
}
