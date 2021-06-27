using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Monagheseh
    {
        public static string ListText
        {
            get
            {
                ResponseSetting setting = ResponseSetting.Load();
                string text = setting.MonaghesatPattern;
                ServiceRepository sr = new ServiceRepository();
                var monaghesat = sr.GetActiveMonaghesat();
                string listText = "";
                foreach (Monagheseh mon in monaghesat)
                {
                    listText +=
                        "عنوان: " + mon.Name + "\n" +
                        "شروع: " + MyHelper.DateToText(mon.DateOfStart, MyEnums.DateType.Short) + "\n" +
                        "پایان: " + MyHelper.DateToText(mon.DateOfEnd, MyEnums.DateType.Short) + "\n" + 
                        "-----" + "\n";
                }
                return (monaghesat.Count() > 0 ? text.Replace(SmsKeywords.List, listText) : "در حال حاضر مناقصه فعالی وجود ندارد");
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
                string url_edit = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditMonagheseh.aspx") + "?Id=" + this.ID.ToString();
                html =
                     "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url_edit + "\" onclick=\"return Open('" + url_edit + "', '', 550, 350);\"></a>";
                return html;
            }
        }
    }
}