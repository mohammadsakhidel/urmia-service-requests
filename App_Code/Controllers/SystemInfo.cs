using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SystemInfo
/// </summary>
public class SystemInfo
{
    ////////////////// Properties:
    public static MyEnums.SystemStatus Status
    {
        get
        {
            string sysPath = HttpContext.Current.Server.MapPath(Urls.SystemFiles + "sys.txt");
            if (System.IO.File.Exists(sysPath))
            {
                int status = Convert.ToInt32(System.IO.File.ReadAllText(sysPath));
                return (MyEnums.SystemStatus)status;
            }
            else
            {
                System.IO.File.WriteAllText(sysPath, ((int)MyEnums.SystemStatus.Running).ToString());
                return MyEnums.SystemStatus.Running;
            }
        }
        set
        {
            string sysPath = HttpContext.Current.Server.MapPath(Urls.SystemFiles + "sys.txt");
            System.IO.File.WriteAllText(sysPath, ((int)value).ToString());
        }
    }

    public static string ErrorMessage
    {
        get
        {
            string sysPath = HttpContext.Current.Server.MapPath(Urls.SystemFiles + "sysMessage.txt");
            if (System.IO.File.Exists(sysPath))
            {
                return System.IO.File.ReadAllText(sysPath);
            }
            else
            {
                System.IO.File.WriteAllText(sysPath, DefaultMessage);
                return DefaultMessage;
            }
        }
        set
        {
            string sysPath = HttpContext.Current.Server.MapPath(Urls.SystemFiles + "sysMessage.txt");
            System.IO.File.WriteAllText(sysPath, value);
        }
    }

    public static string DefaultMessage
    {
        get
        {
            return 
                "خطا: " +
                "کاربر گرامی مهلت استفاده آزمایشی از سیستم به پایان رسیده است. " +
                "لطفاً هر چه سریعتر با طراح سیستم تماس حاصل نمایید.";
        }
    }
}