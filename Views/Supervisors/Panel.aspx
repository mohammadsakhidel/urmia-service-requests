<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/SupervisorPanel.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Views_Supervisors_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width : 50%;">
                    <div class="panel_item">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="panel_icon panel_icon_polling" title="نظرسنجی"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="link_ActivePoll" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/ActivePoll.aspx">نظرسنجی فعال</asp:HyperLink>
                                    <asp:HyperLink ID="link_Polls" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/Polls.aspx">لیست نظرسنجی ها</asp:HyperLink>
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
                                    <asp:HyperLink ID="link_ActiveCompetition" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/ActiveCompetition.aspx">مسابقه فعال</asp:HyperLink>
                                    <asp:HyperLink ID="link_Competitions" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/Competitions.aspx">لیست مسابقه ها</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_reports" title="آمار و گزارشات"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/ReportOfRecievedMessages.aspx">گزارش پیامک های دریافتی</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLinkhbg1" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/ReportOfSuggestions.aspx">گزارش پیشنهادات و انتقادات</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLinkhgj1" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/Charts.aspx">گزارشات نموداری</asp:HyperLink>
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
                                    <div class="panel_icon panel_icon_settings" title="تنظیمات"></div>
                                </td>
                                <td class="td_pad2">
                                    <asp:HyperLink ID="HyperLink15" runat="server" CssClass="panel_item_link" NavigateUrl="~/Views/Supervisors/AcountSettings.aspx">تنظیمات حساب کاربری</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>

    </div>

</asp:Content>

