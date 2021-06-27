using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Citizen
    {
        public string DateOfAddText
        {
            get
            {
                return MyHelper.DateToText(this.DateOfAdd, MyEnums.DateType.Short);
            }
        }

        public string GenderText
        {
            get
            {
                string text = "";
                if (this.Gender != null)
                    text = (this.Gender == (int)MyEnums.Gender.Male ? "مرد" : (this.Gender == (int)MyEnums.Gender.Female ? "زن" : ""));
                return text;
            }
        }

        public string CutedAddress
        {
            get
            {
                return (Address != null ? MyHelper.CutString(this.Address, 25) : "");
            }
        }

        public string HtmlOfDetailsAction
        {
            get
            {
                string html = "";
                string url_details = MyHelper.Url("~/Views/Admins/ToolWindows/DetailsOfCitizen.aspx") + "?Id=" + this.ID.ToString();
                html = "<a class=\"grid_button grid_details\" title=\"جزئیات\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 750, 550);\" style=\"margin-right : 5px;\"></a>";
                return html;
            }
        }

        public int SuggestionsCount
        {
            get
            {
                return this.RecievedMessages.Where(rm => rm.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectSuggestion).Count();
            }
        }

        public int PollsCount
        {
            get
            {
                return this.RecievedMessages.Where(rm => rm.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectPollAnswer).Count();
            }
        }

        public int CompetitionsCount
        {
            get
            {
                return this.RecievedMessages.Where(rm => rm.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer).Count();
            }
        }
    }
}