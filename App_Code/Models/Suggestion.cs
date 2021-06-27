using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Suggestion
    {
        public string HtmlOfNotRoutedsGrid
        {
            get
            {
                string url_route = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/RouteSuggestion.aspx") + "?Id=" + this.ID;
                string html = "";
                html = "<a class=\"grid_button grid_reroute\" title=\"هدایت پیشنهاد\" href=\"" + url_route + "\" onclick=\"return Open('" + url_route + "', '', 700, 450);\"></a>";
                return html;
            }
        }

        public string HtmlOfTrashActions
        {
            get
            {
                string html = "";
                string url_details = MyHelper.Url("~/Views/Admins/ToolWindows/DetailsOfSuggestion.aspx") + "?Id=" + this.ID;
                html = "<a class=\"grid_button grid_details\" title=\"جزئیات پیشنهاد\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 700, 450);\"></a>";
                return html;
            }
        }

        public string GetInformOfRouting(SuggestionRouting routing)
        {
            string informText = "";
            informText += "شهروند گرامی پیامک شما به سازمان زیر ارجاع داده شد:" + 
                "\n" + routing.Organization.Name +
                "\n" + "کد رهگیری: " + this.PersuitCode;
            return informText;
        }

        public string GetInformOfNotRouting()
        {
            string informText = "";
            informText += "شهروند گرامی پیامک شما به کارشناس شبکه ارجاع شد.";
            informText += "\n" + "کد رهگیری: " + this.PersuitCode;
            return informText;
        }

        public string GetInformOfRouting(List<SuggestionRouting> routings)
        {
            string informText = "";
            informText += "شهروند گرامی پیامک شما به سازمان" + (routings.Count() > 1 ? " های" : "") + " زیر ارجاع داده شد:" + "\n";
            int i = 0;
            foreach (SuggestionRouting routing in routings)
            {
                informText += routing.Organization.Name + (i < routings.Count() - 1 ? "\n" : "");
                i++;
            }
            informText += "\n" + "کد رهگیری: " + this.PersuitCode;
            return informText;
        }

        public string GetInformOfRejection(SuggestionRouting routing)
        {
            string informText = "";
            informText += "شهروند گرامی پیامک شما توسط سازمان " + routing.Organization.Name + " به دلایل زیر رد شد:" + 
                "\n" + routing.Explanation +
                "\n" + "کد رهگیری: " + this.PersuitCode;
            return informText;
        }

        public string GetInformOfVerifying(SuggestionRouting routing)
        {
            string informText = "";
            informText += "شهروند گرامی به پیامک شما توسط سازمان " + routing.Organization.Name + " رسیدگی شد، عملیات انجام شده بشرح زیر می باشد:" + 
                "\n" + routing.Explanation +
                "\n" + "کد رهگیری: " + this.PersuitCode;
            return informText;
        }

        public string GetPersuitInformation()
        {
            string info = "";
            info = "کد رهگیری: " + this.PersuitCode + "\n";
            if (this.Status == (int)MyEnums.SuggestionStatus.NotRouted)
            {
                info += "پیامک شما به بخش روابط عمومی ارجاع شده و منتظر رسیدگی است";
            }
            else if (this.Status == (int)MyEnums.SuggestionStatus.Routed)
            {
                if (this.SuggestionRoutings.Count > 0)
                {
                    SuggestionRouting lastRouting = this.SuggestionRoutings.OrderByDescending(r => r.DateOfRoute).First();
                    info += "آخرین ارجاع صورت گرفته :" + "\n";
                    info += "به سازمان " + lastRouting.Organization.Name + " در تاریخ " + MyHelper.DateToText(lastRouting.DateOfRoute, MyEnums.DateType.Short) + "\n";
                    info += "وضعیت ارجاع: " + lastRouting.StatusText;
                }
            }
            return info;
        }

        public string GetInformOfOrganOperators()
        {
            string info = "";
            info = "از شماره: " + this.RecievedMessage.Citizen.MobNumber + " در " + MyHelper.DateToText(this.RecievedMessage.DateOfRecieve, MyEnums.DateType.ShortWithTime) + " پیام زیرارسال شده است، خواهشمنداست رسیدگی فرمایید:" + "\n";
            info += "\"" + this.RecievedMessage.Text + "\"";
            return info;
        }

        public string HtmlOfDetails
        {
            get
            {
                string url_details = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfSuggestion.aspx") + "?Id=" + this.ID;
                string html = "<a class=\"grid_button grid_details\" title=\"جزئیات\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 700, 450);\"></a>";
                return html;
            }
        }
    }
}