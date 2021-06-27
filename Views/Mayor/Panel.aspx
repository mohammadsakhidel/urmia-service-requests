<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/MayorPanel.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Views_Mayor_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_mayorpanel_main" Runat="Server">

    <div class="content">

        <asp:Panel ID="pnl_Info" runat="server" CssClass="panel_item">
            <div class="panel_info" style="width : 70%;">

                <asp:Panel ID="pnl_OutOfDates" runat="server">
                    تعداد
                    <a class="panel_info_link" href='<%= MyHelper.Url("~/Views/Mayor/OutOfDateSuggestions.aspx") %>'>
                        <asp:Label ID="lbl_OutOfDateSuggestionsCount" runat="server" Text="">0</asp:Label>
                        پیام
                    </a>
                    مهلت زمانی لازم جهت پاسخگویی را سپری نموده است.
                </asp:Panel>

            </div>
        </asp:Panel>
    
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_suggestions" title="پیشنهادات و انتقادات"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_RoutedSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/OutOfDateSuggestions.aspx">پیشنهادات تاریخ گذشته</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_polling" title="نظرسنجی"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_ActivePoll" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/ActivePoll.aspx">نظرسنجی فعال</asp:HyperLink>
                                    <asp:HyperLink ID="link_Polls" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/Polls.aspx">لیست نظرسنجی ها</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_competition" title="مسابقه"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_ActiveCompetition" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/ActiveCompetition.aspx">مسابقه فعال</asp:HyperLink>
                                    <asp:HyperLink ID="link_Competitions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/Competitions.aspx">لیست مسابقه ها</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_reports" title="آمار و گزارشات"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/ReportForMayer.aspx">عملکرد ماهانه سازمان ها</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/ReportOfRecievedMessages.aspx">گزارش پیامک های دریافتی</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLinkhbg1" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/ReportOfSuggestions.aspx">گزارش پیشنهادات و انتقادات</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLinkhgj1" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/Charts.aspx">گزارشات نموداری</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_settings" title="تنظیمات"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="HyperLink15" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Mayor/AcountSettings.aspx">تنظیمات حساب کاربری</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    
    </div>

</asp:Content>

