using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.UI.HtmlControls;

public partial class Views_Operators_Panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            Operator op = Operator.CurrentUser;
            OperatorAccessRule accessRule = op.GetOperatorAccessRule();
            HtmlTable tbl_panel = new HtmlTable();
            tbl_panel.Border = 0;
            tbl_panel.CellPadding = 0;
            tbl_panel.CellSpacing = 0;
            tbl_panel.Attributes["style"] = "width:100%;";
            AdminPanelInfo panelInfo = new AdminPanelInfo();
            ///////////// Users:
            if (accessRule.Users != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_users", "مدیریت کاربران", GetUsersLinks(panelInfo));
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// Suggestions:
            if (accessRule.Suggestions != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_suggestions", "پیشنهادات و انتقادات", GetSuggestionsLinks(panelInfo));
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// Polls:
            if (accessRule.Polls != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_polling", "نظرسنجی", GetPollsLinks(panelInfo));
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// Competitions:
            if (accessRule.Competitions != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_competition", "مسابقه", GetCompetitionsLinks(panelInfo));
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// SendSms:
            if (accessRule.SendSms != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_sendSms", "ارسال پیامک", GetSendSmsLinks());
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// Reports:
            if (accessRule.Reports != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_reports", "آمار و گزارشات", GetReportsLinks());
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// Settings:
            if (accessRule.Settings != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_settings", "تنظیمات", GetSettingsLinks());
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ///////////// Services:
            if (accessRule.Services != (int)MyEnums.AccessType.Hidden)
            {
                Panel pnl_item = GetPanelItem("panel_icon_services", "سرویس ها", GetServicesLinks());
                tbl_panel = AddToItemsTable(tbl_panel, pnl_item);
            }
            ////////////////////////////////////////
            pnl_home.Controls.Add(tbl_panel);
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    private HtmlTable AddToItemsTable(HtmlTable tbl_panel, Panel item)
    {
        if (tbl_panel.Rows.Count > 0 && tbl_panel.Rows[tbl_panel.Rows.Count - 1].Cells.Count < 2)
        {
            HtmlTableCell cell = new HtmlTableCell();
            cell.Attributes["style"] = "width:50%;";
            cell.Controls.Add(item);
            tbl_panel.Rows[tbl_panel.Rows.Count - 1].Cells.Add(cell);
        }
        else
        {
            HtmlTableCell cell = new HtmlTableCell();
            cell.Attributes["style"] = "width:50%;";
            cell.Controls.Add(item);
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(cell);
            tbl_panel.Rows.Add(row);
        }
        return tbl_panel;
    }

    private Panel GetPanelItem(string panel_icon_class, string icon_tooltip, List<HyperLink> links)
    {
        Panel pnl_Item = new Panel();
        pnl_Item.CssClass = "panel_item";
        Table tbl_item = new Table();
        // icon cell:
        TableCell cell_icon = new TableCell();
        Panel pnl_icon = new Panel();
        pnl_icon.CssClass = "panel_icon " + panel_icon_class;
        pnl_icon.ToolTip = icon_tooltip;
        //pnl_icon.ToolTip = "";
        cell_icon.Controls.Add(pnl_icon);
        //links cell:
        TableCell cell_links = new TableCell();
        cell_links.CssClass = "td_pad1";
        foreach (HyperLink link in links)
        {
            cell_links.Controls.Add(link);
        }
        TableRow row = new TableRow();
        row.Cells.Add(cell_icon);
        row.Cells.Add(cell_links);
        tbl_item.Rows.Add(row);
        pnl_Item.Controls.Add(tbl_item);
        return pnl_Item;
    }

    private List<HyperLink> GetUsersLinks(AdminPanelInfo info)
    {
        ////**********links:
        HyperLink link_Organizations = new HyperLink();
        link_Organizations.ID = "link_Organizations";
        link_Organizations.CssClass = "panel_item_link";
        link_Organizations.Text = "سازمان ها" + " " + "(" + info.OrganizationsCount.ToString() + ")";
        link_Organizations.NavigateUrl = "~/Views/Operators/Organizations.aspx";
        ////
        HyperLink link_Operators = new HyperLink();
        link_Operators.ID = "link_Operators";
        link_Operators.CssClass = "panel_item_link";
        link_Operators.Text = "اپراتورهای شبکه" + " " + "(" + info.OperatorsCount.ToString() + ")";
        link_Operators.NavigateUrl = "~/Views/Operators/Operators.aspx";
        ////
        HyperLink link_Supervisors = new HyperLink();
        link_Supervisors.ID = "link_Supervisors";
        link_Supervisors.CssClass = "panel_item_link";
        link_Supervisors.Text = "ناظرین شبکه" + " " + "(" + info.SupervisorsCount.ToString() + ")";
        link_Supervisors.NavigateUrl = "~/Views/Operators/Supervisors.aspx";
        ////
        HyperLink link_Citizens = new HyperLink();
        link_Citizens.ID = "link_Citizens";
        link_Citizens.CssClass = "panel_item_link";
        link_Citizens.Text = "شهرواندان" + " " + "(" + info.CitizensCount.ToString() + ")";
        link_Citizens.NavigateUrl = "~/Views/Operators/Citizens.aspx";
        return (new HyperLink[] { link_Organizations, link_Operators, link_Supervisors, link_Citizens }).ToList();
    }

    private List<HyperLink> GetSuggestionsLinks(AdminPanelInfo info)
    {
        ////**********links:
        HyperLink link_RoutedSuggestions = new HyperLink();
        link_RoutedSuggestions.ID = "link_RoutedSuggestions";
        link_RoutedSuggestions.CssClass = "panel_item_link";
        link_RoutedSuggestions.Text = "صندوق سازمان" + " " + "(" + info.RoutedSuggestionsCount.ToString() + ")";
        link_RoutedSuggestions.NavigateUrl = "~/Views/Operators/RoutedSuggestions.aspx";
        ////
        HyperLink link_NotRoutedSuggestions = new HyperLink();
        link_NotRoutedSuggestions.ID = "link_NotRoutedSuggestions";
        link_NotRoutedSuggestions.CssClass = "panel_item_link";
        link_NotRoutedSuggestions.Text = "پیامک های هدایت نشده" + " " + "(" + info.NotRoutedSuggestionsCount.ToString() + ")";
        link_NotRoutedSuggestions.NavigateUrl = "~/Views/Operators/NotRoutedSuggestions.aspx";
        ////
        HyperLink link_PersuitSuggestion = new HyperLink();
        link_PersuitSuggestion.ID = "link_PersuitSuggestion";
        link_PersuitSuggestion.CssClass = "panel_item_link";
        link_PersuitSuggestion.Text = "رهگیری پیشنهادات";
        link_PersuitSuggestion.NavigateUrl = "~/Views/Operators/PersuitSuggestion.aspx";
        return (new HyperLink[] { link_RoutedSuggestions, link_NotRoutedSuggestions, link_PersuitSuggestion }).ToList();
    }

    private List<HyperLink> GetPollsLinks(AdminPanelInfo info)
    {
        ////**********links:
        HyperLink link_ActivePoll = new HyperLink();
        link_ActivePoll.ID = "link_ActivePoll";
        link_ActivePoll.CssClass = "panel_item_link";
        link_ActivePoll.NavigateUrl = "~/Views/Operators/ActivePoll.aspx";
        if (info.ActivePollAnswersCount >= 0)
            link_ActivePoll.Text = "نظرسنجی فعال" + " " + "(نظرات : " + info.ActivePollAnswersCount.ToString() + ")";
        else
        {
            link_ActivePoll.Text = "نظرسنجی فعال";
            link_ActivePoll.Enabled = false;
            link_ActivePoll.CssClass = "panel_item_link_disabled";
        }
        ////
        HyperLink link_Polls = new HyperLink();
        link_Polls.ID = "link_Polls";
        link_Polls.CssClass = "panel_item_link";
        link_Polls.Text = "لیست نظرسنجی ها" + " " + "(" + info.PollsCount.ToString() + ")";
        link_Polls.NavigateUrl = "~/Views/Operators/Polls.aspx";
        return (new HyperLink[] { link_ActivePoll, link_Polls }).ToList();
    }

    private List<HyperLink> GetCompetitionsLinks(AdminPanelInfo info)
    {
        ////**********links:
        HyperLink link_ActiveCompetition = new HyperLink();
        link_ActiveCompetition.ID = "link_ActiveCompetition";
        link_ActiveCompetition.CssClass = "panel_item_link";
        link_ActiveCompetition.NavigateUrl = "~/Views/Operators/ActiveCompetition.aspx";
        if (info.ActiveCompetitionAnswersCount >= 0)
            link_ActiveCompetition.Text = "مسابقه فعال" + " " + "(پاسخ ها : " + info.ActiveCompetitionAnswersCount.ToString() + ")";
        else
        {
            link_ActiveCompetition.Text = "مسابقه فعال";
            link_ActiveCompetition.Enabled = false;
            link_ActiveCompetition.CssClass = "panel_item_link_disabled";
        }
        ////
        HyperLink link_Competitions = new HyperLink();
        link_Competitions.ID = "link_Competitions";
        link_Competitions.CssClass = "panel_item_link";
        link_Competitions.Text = "لیست مسابقه ها" + " " + "(" + info.CompetitionsCount.ToString() + ")";
        link_Competitions.NavigateUrl = "~/Views/Operators/Competitions.aspx";
        return (new HyperLink[] { link_ActiveCompetition, link_Competitions }).ToList();
    }

    private List<HyperLink> GetSendSmsLinks()
    {
        ////**********links:
        HyperLink link_send1 = new HyperLink();
        link_send1.ID = "link_send1";
        link_send1.CssClass = "panel_item_link";
        link_send1.Text = "دفترچه تلفن";
        link_send1.NavigateUrl = "~/Views/Operators/Contacts.aspx";
        ////
        HyperLink link_send2 = new HyperLink();
        link_send2.ID = "link_send2";
        link_send2.CssClass = "panel_item_link";
        link_send2.Text = "الگوهای آماده";
        link_send2.NavigateUrl = "~/Views/Operators/Patterns.aspx";
        ////
        HyperLink link_send3 = new HyperLink();
        link_send3.ID = "link_send3";
        link_send3.CssClass = "panel_item_link";
        link_send3.Text = "ارسال پیامک جدید";
        link_send3.NavigateUrl = "~/Views/Operators/SendSMS.aspx";
        if (!Permissions.SendSmsWritePermission)
        {
            link_send3.Enabled = false;
            link_send3.CssClass = "panel_item_link_disabled";
        }
        ////
        HyperLink link_send4 = new HyperLink();
        link_send4.ID = "link_send4";
        link_send4.CssClass = "panel_item_link";
        link_send4.Text = "پیامک های ارسال شده";
        link_send4.NavigateUrl = "~/Views/Operators/SentBox.aspx";
        return (new HyperLink[] { link_send1, link_send2, link_send3, link_send4 }).ToList();
    }

    private List<HyperLink> GetReportsLinks()
    {
        ////**********links:
        HyperLink link_reports1 = new HyperLink();
        link_reports1.ID = "link_send1";
        link_reports1.CssClass = "panel_item_link";
        link_reports1.Text = "گزارش پیامک های دریافتی";
        link_reports1.NavigateUrl = "~/Views/Operators/ReportingRecievedMessages.aspx";
        ////
        HyperLink link_reports2 = new HyperLink();
        link_reports2.ID = "link_send2";
        link_reports2.CssClass = "panel_item_link";
        link_reports2.Text = "گزارش پیشنهادات و انتقادات";
        link_reports2.NavigateUrl = "~/Views/Operators/ReportingSuggestions.aspx";
        ////
        HyperLink link_reports3 = new HyperLink();
        link_reports3.ID = "link_send3";
        link_reports3.CssClass = "panel_item_link";
        link_reports3.Text = "گزارشات نموداری";
        link_reports3.NavigateUrl = "~/Views/Operators/Charts.aspx";
        return (new HyperLink[] { link_reports1, link_reports2, link_reports3 }).ToList();
    }

    private List<HyperLink> GetSettingsLinks()
    {
        ////**********links:
        HyperLink link_setting1 = new HyperLink();
        link_setting1.ID = "link_send1";
        link_setting1.CssClass = "panel_item_link";
        link_setting1.Text = "تنظیمات سیستم";
        link_setting1.NavigateUrl = "~/Views/Operators/Settings.aspx";
        ////
        HyperLink link_setting2 = new HyperLink();
        link_setting2.ID = "link_send2";
        link_setting2.CssClass = "panel_item_link";
        link_setting2.Text = "تنظیمات حساب کاربری";
        link_setting2.NavigateUrl = "~/Views/Operators/AcountSettings.aspx";
        return (new HyperLink[] { link_setting1, link_setting2 }).ToList();
    }

    private List<HyperLink> GetServicesLinks()
    {
        ////**********links:
        HyperLink link_service1 = new HyperLink();
        link_service1.ID = "link_send1";
        link_service1.CssClass = "panel_item_link";
        link_service1.Text = "مناقصات";
        link_service1.NavigateUrl = "~/Views/Operators/Monaghesat.aspx";
        ////
        HyperLink link_service2 = new HyperLink();
        link_service2.ID = "link_send2";
        link_service2.CssClass = "panel_item_link";
        link_service2.Text = "مزایده ها";
        link_service2.NavigateUrl = "~/Views/Operators/Mozaiedat.aspx";
        return (new HyperLink[] { link_service1, link_service2 }).ToList();
    }
}