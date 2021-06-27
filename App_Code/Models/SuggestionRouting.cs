using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SuggestionRouting
/// </summary>
namespace Models
{
    public partial class SuggestionRouting
    {
        public string StatusText
        {
            get
            {
                string text = "";
                if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Pending)
                    text = "منتظر پاسخ";
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected)
                    text = "رد شده";
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Verified)
                    text = "رسیدگی شده";
                return text;
            }
        }

        public System.Drawing.Color StatusColor
        {
            get
            {
                System.Drawing.Color color = System.Drawing.Color.White;
                if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Pending)
                    color = System.Drawing.Color.FromArgb(255, 255, 255, 175);
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected)
                    color = System.Drawing.Color.FromArgb(255, 255, 175, 175);
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Verified)
                    color = System.Drawing.Color.FromArgb(255, 175, 255, 175);
                return color;
            }
        }

        public string StatusStyle
        {
            get
            {
                string cssStyle = "";
                if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Pending)
                    cssStyle = "pending_suggestion";
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected)
                    cssStyle = "rejected_suggestion";
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Verified)
                    cssStyle = "verified_suggestion";
                return cssStyle;
            }
        }

        public string HtmlOfTrashActions
        {
            get
            {
                string html = "";
                string url_details = MyHelper.Url("~/Views/Admins/ToolWindows/DetailsOfSuggestion.aspx") + "?Id=" + this.SuggestionID;
                html = "<a class=\"grid_button grid_details\" title=\"جزئیات پیشنهاد\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 700, 450);\"></a>";
                return html;
            }
        }

        public string HtmlOfGridActions
        {
            get
            {
                string html = "";
                string root = "~/Views/" + MyRoles.FolderName + "/ToolWindows/";
                string url_details = MyHelper.Url(root + "DetailsOfSuggestion.aspx") + "?Id=" + this.SuggestionID;
                if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Pending)
                {
                    string url_reject = MyHelper.Url(root + "RejectSuggestion.aspx") + "?Id=" + this.ID;
                    string url_verify = MyHelper.Url(root + "VerifySuggestion.aspx") + "?Id=" + this.ID;
                    html =
                        "<a class=\"grid_button grid_details\" title=\"جزئیات تمام ارجاعات\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 700, 450);\"></a>" +
                        (Permissions.SuggestionsWritePermission ?
                        "<a class=\"grid_button grid_verify\" title=\"ثبت اقدامات\" href=\"" + url_verify + "\" onclick=\"return Open('" + url_verify + "', '', 700, 400);\" style=\"margin-right : 3px;\"></a>" +
                        "<a class=\"grid_button grid_reject\" title=\"رد پیشنهاد\" href=\"" + url_reject + "\" onclick=\"return Open('" + url_reject + "', '', 700, 400);\" style=\"margin-right : 2px;\"></a>"
                        : "");
                }
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected)
                {
                    string url_reroute = MyHelper.Url(root + "RouteSuggestion.aspx") + "?Id=" + this.SuggestionID;
                    html =
                        "<a class=\"grid_button grid_details\" title=\"جزئیات تمام ارجاعات\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 700, 450);\"></a>" +
                        (Permissions.SuggestionsRoutePermission ?
                        "<a class=\"grid_button grid_reroute\" title=\"هدایت دوباره\" href=\"" + url_reroute + "\" onclick=\"return Open('" + url_reroute + "', '', 700, 550);\" style=\"margin-right : 3px;\"></a>" : 
                        "");
                        
                }
                else if (this.Status == (int)MyEnums.SuggestionRoutingStatus.Verified)
                {
                    html = "<a class=\"grid_button grid_details\" title=\"جزئیات تمام ارجاعات\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 700, 450);\"></a>";
                }
                return html;
            }
        }

        public bool IsOutOfDate
        {
            get
            {
                return this.Status == (int)MyEnums.SuggestionRoutingStatus.Pending && this.DateOfRoute.AddDays(Digits.OutOfDateDays).Date < MyHelper.Now.Date ? true : false;
            }
        }

    }
}