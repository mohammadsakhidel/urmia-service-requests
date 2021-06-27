<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Views_Admins_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">
    <div class="content">

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_users" title="مدیریت کاربران"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_Organizations" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Organizations.aspx">سازمان ها</asp:HyperLink>
                                    <asp:HyperLink ID="link_Operators" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Operators.aspx">اپراتورهای شبکه</asp:HyperLink>
                                    <asp:HyperLink ID="link_Supervisors" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Supervisors.aspx">ناظرین شبکه</asp:HyperLink>
                                    <asp:HyperLink ID="link_Citizens" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Citizens.aspx">شهرواندان</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_suggestions" title="پیشنهادات و انتقادات"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_RoutedSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/RoutedSuggestions.aspx">صندوق سازمان</asp:HyperLink>
                                    <asp:HyperLink ID="link_NotRoutedSuggestions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/NotRoutedSuggestions.aspx">صندوق پیشنهادات هدایت نشده</asp:HyperLink>
                                    <asp:HyperLink ID="link_SuggestionsTrash" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/SuggestionsTrash.aspx">بازیافت</asp:HyperLink>
                                    <asp:HyperLink ID="link_PersuitSuggestion" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/PersuitSuggestion.aspx">رهگیری پیشنهادات</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_polling" title="نظرسنجی"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_ActivePoll" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/ActivePoll.aspx">نظرسنجی فعال</asp:HyperLink>
                                    <asp:HyperLink ID="link_Polls" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Polls.aspx">لیست نظرسنجی ها</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_competition" title="مسابقه"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_ActiveCompetition" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/ActiveCompetition.aspx">مسابقه فعال</asp:HyperLink>
                                    <asp:HyperLink ID="link_Competitions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Competitions.aspx">لیست مسابقه ها</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_sendSms" title="ارسال پیامک"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Contacts.aspx">دفترچه تلفن</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Patterns.aspx">الگوهای آماده</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/SendSMS.aspx">ارسال پیامک جدید</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/SentBox.aspx">پیامک های ارسال شده</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/ReportingRecievedMessages.aspx">گزارش پیامک های دریافتی</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/ReportingSuggestions.aspx">گزارش پیشنهادات و انتقادات</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Charts.aspx">گزارشات نموداری</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink15" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Settings.aspx">تنظیمات سیستم</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/AcountSettings.aspx">تنظیمات حساب کاربری</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_services" title="سرویس ها"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Monaghesat.aspx">مناقصات</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Admins/Mozaiedat.aspx">مزایده ها</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>

        </table>

    </div>
</asp:Content>

