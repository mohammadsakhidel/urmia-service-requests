using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Models
{
    public partial class RecievedMessage
    {
        public MyEnums.RecievedMessageType Type
        {
            get
            {
                Regex rgx_persuitCode = new Regex(@"^[A-Za-z]{12}$");
                Regex rgx_serviceCode = new Regex(@"^\d{3}$");
                Regex rgx_pollAnswer = new Regex(@"^\d{1}$");
                MyEnums.RecievedMessageType type = MyEnums.RecievedMessageType.None;
                ///////////
                if (rgx_persuitCode.IsMatch(this.Text))
                    type = MyEnums.RecievedMessageType.Persuiting;
                else if (rgx_serviceCode.IsMatch(this.Text))
                    type = MyEnums.RecievedMessageType.ServiceRequest;
                else if (rgx_pollAnswer.IsMatch(this.Text))
                    type = MyEnums.RecievedMessageType.PollAnswer;
                else if (this.Text.StartsWith("**"))
                    type = MyEnums.RecievedMessageType.CompetitionAnswer;
                else if (this.Text.StartsWith("raman:"))
                    type = MyEnums.RecievedMessageType.MyAction;
                else if (RecievedMessage.IsSuggestion(this.Text))
                    type = MyEnums.RecievedMessageType.Suggestion;
                //////////
                return type;
            }
        }

        public string CommingCompetitionAnswer
        {
            get
            {
                string text = "";
                if (this.Type == MyEnums.RecievedMessageType.CompetitionAnswer)
                    text = this.Text.Substring(2, this.Text.Length - 2);
                return text;
            }
        }

        public string DateOfRecieveText
        {
            get
            {
                return Controllers.ShamsiDateTime.MiladyToShamsi(this.DateOfRecieve).ToMediumString() + " ساعت " + this.DateOfRecieve.Hour.ToString("D2") + ":" + this.DateOfRecieve.Minute.ToString("D2");
            }
        }

        public string DateOfRecieveShortText
        {
            get
            {
                return Controllers.ShamsiDateTime.MiladyToShamsi(this.DateOfRecieve).ToString() + " - " + this.DateOfRecieve.Hour.ToString("D2") + ":" + this.DateOfRecieve.Minute.ToString("D2");
            }
        }

        public string CutedText
        {
            get
            {
                return MyHelper.CutString(this.Text, 25);
            }
        }

        public string ProcessResultText
        {
            get
            {
                string text = "";
                if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer)
                    text = "پاسخ مسابقه";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectPollAnswer)
                    text = "نظر";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectSuggestion)
                    text = "پیشنهاد";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.IncorrectCompetitionOptionSelected)
                    text = "گزینه اشتباه مسابقه";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.IncorrectFormat)
                    text = "فرمت اشتباه";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.IncorrectPollOptionSelected)
                    text = "گزینه اشتباه نظرسنجی";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.NoActiveCompetitionExists)
                    text = "عدم وجود مسابقه فعال";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.NoActivePollExists)
                    text = "عدم وجود نظرسنجی فعال";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.NotProcessed)
                    text = "پردازش نشده";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectPersuitCode)
                    text = "رهگیری پیشنهاد";
                else if (this.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.IncorrectPersuitCode)
                    text = "کد رهگیری اشتباه";
                return text;
            }
        }

        public static bool IsSuggestion(string text)
        {
            bool res = true;
            ///// words count check:
            List<string> words = MyHelper.GetWords(text);
            if (words.Count() < 3)
                res = false;
            /////
            return res;
        }
    }
}
