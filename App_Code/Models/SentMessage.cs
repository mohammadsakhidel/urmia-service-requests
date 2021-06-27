using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models
{
    public partial class SentMessage
    {
        public string DateOfSendText
        {
            get
            {
                return MyHelper.DateToText(this.DateOfSend, MyEnums.DateType.MediumWithTime);
            }
        }

        public string HtmlOfDetailsButton
        {
            get
            {
                return "<a class=\"grid_button grid_details\" onclick=\"return Open('" + MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfSentMessage.aspx") + "?Id=" + this.ID + "', '', 750, 550);\"></a>";
            }
        }

        public string HtmlOfText
        {
            get
            {
                return this.Text.Replace("\n", "<br />");
            }
        }
    }
}