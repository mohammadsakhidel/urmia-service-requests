using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class OperatorAccessRule
    {
        public static OperatorAccessRule Default
        {
            get
            {
                OperatorAccessRule rule = new OperatorAccessRule();
                rule.Users = (int)MyEnums.AccessType.Hidden;
                rule.Suggestions = (int)MyEnums.AccessType.ReadWrite;
                rule.Polls = (int)MyEnums.AccessType.ReadWrite;
                rule.Competitions = (int)MyEnums.AccessType.ReadWrite;
                rule.SendSms = (int)MyEnums.AccessType.ReadWrite;
                rule.Reports = (int)MyEnums.AccessType.ReadWrite;
                rule.Services = (int)MyEnums.AccessType.ReadWrite;
                rule.Settings = (int)MyEnums.AccessType.Read;
                return rule;
            }
        }
    }
}