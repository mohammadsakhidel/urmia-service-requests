using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

public class MyHelper
{
    public static string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        }
    }
    public static DateTime Now
    {
        get
        {
            return DateTime.Now;
        }
    }
    public static string Url(string aspUrl)
    {
        return VirtualPathUtility.ToAbsolute(aspUrl);
    }
    public static bool IsUserAuthenticated
    {
        get { return HttpContext.Current.User.Identity.IsAuthenticated; }
    }
    public static string CurrentUserName
    {
        get { return HttpContext.Current.User.Identity.Name; }
    }
    public static System.Security.Principal.IPrincipal User
    {
        get { return HttpContext.Current.User; }
    }
    public static bool IsValidRequest()
    {
        //temporarly returns true:
        return true;
    }
    public static void MessageBoxShow(string MessageText, System.Web.UI.Control ctrl, Type typeOfControl)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(ctrl, typeOfControl, "click", @"alert('" + MessageText + "');", true);
    }
    public static string GetRandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }
    public static List<string> SplitString(string text, string splitter)
    {
        List<string> list = new List<string>();
        if (!String.IsNullOrEmpty(text))
        {
            Regex rgx = new Regex(splitter);
            string[] array = rgx.Split(text);
            foreach (string st in array)
            {
                if (st.Trim().Length > 0)
                    list.Add(st);
            }
        }
        return list;
    }
    public static List<string> GetLines(string text)
    {
        Regex rgx = new Regex("\n");
        string[] array = rgx.Split(text);
        List<string> list = new List<string>();
        foreach (string st in array)
        {
            list.Add(st);
        }
        return list;
    }
    public static List<string> GetWords(string text)
    {
        Regex rgx = new Regex(@"\s+");
        string[] array = rgx.Split(text);
        List<string> list = new List<string>();
        foreach (string st in array)
        {
            if (st.Trim().Length > 0)
                list.Add(st);
        }
        return list;
    }
    public static string CutString(object text, int maxLenght)
    {
        string res = "";
        if (text.ToString().Length < maxLenght)
        {
            res = text.ToString();
        }
        else
        {
            res = text.ToString().Substring(0, maxLenght) + " ...";
        }
        return res;
    }
    public static bool IsCorrectUserName(string userName)
    {
        return true;
    }
    public static bool IsCorrectPassword(string password)
    {
        return true;
    }
    public static Control FindControl(ControlCollection collection, Type type)
    {
        Control control = null;
        foreach (Control c in collection)
        {
            if (c.GetType() == type)
                return c;
        }
        return control;
    }
    public static bool IsInteger(string text)
    {
        bool res = false;
        int outInt = 0;
        res = Int32.TryParse(text, out outInt);
        return res;
    }
    public static string ExtractMobNumber(string rawNumber)
    {
        string res = "";
        if (rawNumber.Length >= 10)
            res = rawNumber.Substring(rawNumber.Length - 10, 10);
        return res;
    }
    public static bool IsValidMobNumber(string rawNumber)
    {
        bool res = false;
        if (rawNumber.Length >= 10 && ExtractMobNumber(rawNumber).StartsWith("9"))
        {
            res = true;
        }
        return res;
    }
    public static string Trim(string text)
    {
        return text.Replace(" ", "").Trim();
    }
    public static System.Drawing.Color GetRandomColor()
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        System.Drawing.Color color = System.Drawing.Color.FromArgb(240, (byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
        return color;
    }
    public static string DateToText(DateTime date, MyEnums.DateType type)
    {
        string text = "";
        Controllers.ShamsiDateTime shamsi = Controllers.ShamsiDateTime.MiladyToShamsi(date);
        ////step1:
        if (type == MyEnums.DateType.Short || type == MyEnums.DateType.ShortWithTime)
            text = shamsi.ToString();
        else if (type == MyEnums.DateType.Medium || type == MyEnums.DateType.MediumWithTime)
            text = shamsi.ToMediumString();
        ////step2:
        if (type == MyEnums.DateType.ShortWithTime)
            text += " - " + date.Hour.ToString("D2") + ":" + date.Minute.ToString("D2");
        else if (type == MyEnums.DateType.MediumWithTime)
            text += " ساعت " + date.Hour.ToString("D2") + ":" + date.Minute.ToString("D2");
        return text;
    }
    public static bool IsMobNumber(string number)
    {
        bool res = false;
        Regex rgx = new Regex(@"^9\d{9}$");
        if (number.Length >= 10)
            res = rgx.IsMatch(number.Substring(number.Length - 10, 10));
        return res;
    }
    public static int FindIndex(System.Web.UI.WebControls.ListItemCollection items, string value)
    {
        int index = -1;
        for (int i=0; i<items.Count; i++)
        {
            System.Web.UI.WebControls.ListItem item = items[i];
            if (item.Value == value)
                return i;
        }
        return index;
    }
    public static Hashtable GetHashtableFromString(string info)
    {
        Hashtable hash = new Hashtable();
        List<string> keyvalues = SplitString(info, ";");
        foreach (string keyValue in keyvalues)
        {
            List<string> kv = SplitString(keyValue, ":");
            hash[kv[0]] = kv[1];
        }
        return hash;
    }
    public static string ToPersian(string text)
    {
        string persian = "";
        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            persian += FindPersianChar(letter);
        }
        return persian;
    }
    private static char FindPersianChar(char letter)
    {
        char persianChar = letter;
        if ((new int[] { 1571, 1573 }).Contains((int)letter)) //ا
        {
            persianChar = (char)1575;
        }
        else if ((int)letter == 1577) //ه
        {
            persianChar = (char)1607;
        }
        else if ((new int[] { 1603, 1706, 1707, 1708, 1709, 1710 }).Contains((int)letter)) //ک
        {
            persianChar = (char)1705;
        }
        else if ((new int[] { 1574, 1609, 1610, 1656 }).Contains((int)letter)) //ی
        {
            persianChar = (char)1740;
        }
        else if ((new int[] { 1572, 1654, 1655, 1732, 1733, 1734, 1735, 1736, 1737, 1738, 1739 }).Contains((int)letter)) //و
        {
            persianChar = (char)1608;
        }
        return persianChar;
    }
}