using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaticValues
/// </summary>
public class MyRoles
{
    public static string Administrator { get { return "Administrator"; } }
    public static string Operator { get { return "Operator"; } }
    public static string Organization { get { return "Organization"; } }
    public static string Supervisor { get { return "Supervisor"; } }
    public static string Mayor { get { return "Mayor"; } }
    public static string FolderName
    {
        get
        {
            string name = "";
            name = (HttpContext.Current.User.IsInRole(MyRoles.Administrator) ? "Admins" : (HttpContext.Current.User.IsInRole(MyRoles.Operator) ? "Operators" : (HttpContext.Current.User.IsInRole(MyRoles.Supervisor) ? "Supervisors" : (HttpContext.Current.User.IsInRole(MyRoles.Organization) ? "Organizations" : (HttpContext.Current.User.IsInRole(MyRoles.Mayor) ? "Mayor" : "Shared")))));
            return name;
        }
    }
}

public class SmsKeywords
{
    public static string List { get { return "--list--"; } }
}

public class Urls
{
    public static string TempFiles { get { return "~/Content/TempFiles/"; } }
    public static string SystemFiles { get { return "~/Content/SystemFiles/"; } }
    public static string Downloadable { get { return "~/Content/Downloadable/"; } }
}

public class ServiceCodes
{
    public static int Monaghesat { get { return 101; } }
    public static int Mozaiedat { get { return 102; } }
}

public class Digits
{
    public static int MaxMonaghesatPerSms { get { return 5; } }
    public static int MaxMozaiedatPerSms { get { return 5; } }
    public static int OutOfDateDays { get { return 7; } }
}