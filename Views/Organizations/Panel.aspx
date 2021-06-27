<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OrganPanel.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Views_Organizations_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">

        <asp:Panel ID="pnl_Info" runat="server" CssClass="panel_item">
            <div class="panel_info" style="width : 70%;">

                <asp:Panel ID="pnl_Pendings" runat="server">
                    شما دارای
                    <a class="panel_info_link" href='<%= MyHelper.Url("~/Views/Organizations/PendingSuggestions.aspx") %>'>
                        <asp:Label ID="lbl_PendingSuggestionsCount" runat="server" Text=""></asp:Label>
                        پیام مننظر پاسخ
                    </a>
                    هستید.
                </asp:Panel>

                <asp:Panel ID="pnl_OutOfDates" runat="server" style="margin-top : 15px;" CssClass="panel_info_caution">
                    کاربر گرامی
                    <a class="panel_info_link" href='<%= MyHelper.Url("~/Views/Organizations/OutOfDateSuggestions.aspx") %>'>
                        <asp:Label ID="lbl_OutOfDatesCount" runat="server" Text=""></asp:Label>
                        پیام
                    </a>
                    مهلت لازم جهت پاسخگویی را سپری نموده است.
                    <div style="font-weight : normal; margin-top : 7px;">
                        در صورت عدم پاسخ بموقع، سیستم مسئولین مربوطه را آگاه خواهد ساخت.
                    </div>
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
                                    <asp:HyperLink ID="link_PendingSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/PendingSuggestions.aspx">منتظر پاسخ</asp:HyperLink>
                                    <asp:HyperLink ID="link_VerifiedSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/VerifiedSuggestions.aspx">رسیدگی شده</asp:HyperLink>
                                    <asp:HyperLink ID="link_RejectedSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/RejectedSuggestions.aspx">رد شده</asp:HyperLink>
                                    <asp:HyperLink ID="link_NotRoutedSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/NotRoutedSuggestions.aspx">پیامک های هدایت نشده</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/ReportOfSuggestions.aspx">گزارش پیشنهادات و انتقادات</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/Charts.aspx">گزارشات نموداری</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink15" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Organizations/AcountSettings.aspx">تنظیمات حساب کاربری</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width : 50%;">
                </td>
            </tr>
        </table>
    
    </div>

</asp:Content>

