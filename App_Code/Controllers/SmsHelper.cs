using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Wpf_SmsManager.MyServices;

namespace Controllers
{
    public class SmsHelper
    {
        public void Send(string text, string telNumber, bool saveAsInteractiveMessage)
        {
            OppWebService.Service service = new OppWebService.Service();
            service.SendSMS(SmsAcount.UserName, SmsAcount.Password, SmsAcount.TelNo, new string[] { telNumber }, text);
            ////////// Save As Interactive Sent Message :
            if (saveAsInteractiveMessage)
            {
                SmsRepository sr = new SmsRepository();
                Models.InteractiveSentMessage sentMessage = new Models.InteractiveSentMessage();
                sentMessage.Text = text;
                sentMessage.MobNumber = telNumber;
                sentMessage.DateOfSend = MyHelper.Now;
                sr.AddInteractiveSentMessage(sentMessage);
                sr.Save();
            }
        }

        public void Send(string text, List<string> telNumbers)
        {
            OppWebService.Service service = new OppWebService.Service();
            service.SendSMS(SmsAcount.UserName, SmsAcount.Password, SmsAcount.TelNo, telNumbers.ToArray(), text);
        }

    }
}
