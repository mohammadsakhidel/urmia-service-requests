using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controllers
{
    public class SMSMessage
    {
        public SMSMessage(string from, string to, string text, DateTime dateOfSend, DateTime dateOfRecieve)
        {
            From = from;
            To = to;
            Text = text;
            DateOfSend = dateOfRecieve;
            DateOfRecieve = dateOfRecieve;
        }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public DateTime DateOfSend { get; set; }
        public DateTime DateOfRecieve { get; set; }
    }
}
