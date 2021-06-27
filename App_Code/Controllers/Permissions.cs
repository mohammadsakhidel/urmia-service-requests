using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// Summary description for Permissions
/// </summary>
public class Permissions
{
    //***************************************************************** USERS:
    #region Users Permissions:

    public static bool UsersWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Users == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    public static bool UsersViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Users != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** SUGGESTIONS:
    #region Suggestions Permissions:

    public static bool SuggestionsViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || MyHelper.User.IsInRole(MyRoles.Organization) || (MyHelper.User.IsInRole(MyRoles.Operator) && Operator.CurrentUser.GetOperatorAccessRule().Suggestions != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    public static bool SuggestionsWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || MyHelper.User.IsInRole(MyRoles.Organization) || (MyHelper.User.IsInRole(MyRoles.Operator) && Operator.CurrentUser.GetOperatorAccessRule().Suggestions == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    public static bool SuggestionsDeletePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Operator.CurrentUser.GetOperatorAccessRule().Suggestions == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    public static bool SuggestionsRoutePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Operator.CurrentUser.GetOperatorAccessRule().Suggestions == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** Polls:
    #region Polls Permissions:

    public static bool PollsWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Polls == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    public static bool PollsViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || MyHelper.User.IsInRole(MyRoles.Supervisor) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Polls != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** Competitions:
    #region Competitions Permissions:

    public static bool CompetitionsWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Competitions == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    public static bool CompetitionsViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || MyHelper.User.IsInRole(MyRoles.Supervisor) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Competitions != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** SendSms:
    #region SendSms Permissions:

    public static bool SendSmsWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().SendSms == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    public static bool SendSmsViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().SendSms != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** Reports:
    #region Reports Permissions:

    public static bool ReportsViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || MyHelper.User.IsInRole(MyRoles.Organization) || MyHelper.User.IsInRole(MyRoles.Supervisor) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Reports != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** Settings:
    #region Settings Permissions:

    public static bool SettingsViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Settings != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    public static bool SettingsWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Settings == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    #endregion
    //***************************************************************** Services:
    #region Services Permissions:

    public static bool ServicesViewPermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Services != (int)MyEnums.AccessType.Hidden))
                res = true;
            return res;
        }
    }

    public static bool ServicesWritePermission
    {
        get
        {
            bool res = false;
            if (MyHelper.User.IsInRole(MyRoles.Administrator) || (MyHelper.User.IsInRole(MyRoles.Operator) && Models.Operator.CurrentUser.GetOperatorAccessRule().Services == (int)MyEnums.AccessType.ReadWrite))
                res = true;
            return res;
        }
    }

    #endregion

}