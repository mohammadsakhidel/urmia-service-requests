using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Mozaiedeh
    {
        public static string ListText
        {
            get
            {
                ResponseSetting setting = ResponseSetting.Load();
                string text = setting.MozaiedatPattern;
                ServiceRepository sr = new ServiceRepository();
                var mozaiedat = sr.GetActiveMozaiedat();
                string listText = "";
                foreach (Mozaiedeh moz in mozaiedat)
                {
                    listText +=
                        "عنوان: " + moz.Name + "\n" +
                        "شروع: " + MyHelper.DateToText(moz.DateOfStart, MyEnums.DateType.Short) + "\n" +
                        "پایان: " + MyHelper.DateToText(moz.DateOfEnd, MyEnums.DateType.Short) + "\n" +
                        "-----" + "\n";
                }
                return (mozaiedat.Count() > 0 ? text.Replace(SmsKeywords.List, listText) : "در حال حاضر مزایده فعالی وجود ندارد");
            }
        }

        public string CutedName
        {
            get
            {
                return MyHelper.CutString(Name, 25);
            }
        }

        public string DateOfStartText
        {
            get
            {
                return MyHelper.DateToText(this.DateOfStart, MyEnums.DateType.Short);
            }
        }

        public string DateOfEndText
        {
            get
            {
                return MyHelper.DateToText(this.DateOfEnd, MyEnums.DateType.Short);
            }
        }

        public string HtmlOfGridActions
        {
            get
            {
                string html = "";
                string url_edit = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditMozaiedeh.aspx") + "?Id=" + this.ID.ToString();
                html =
                     "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url_edit + "\" onclick=\"return Open('" + url_edit + "', '', 550, 350);\"></a>";
                return html;
            }
        }
    }
}