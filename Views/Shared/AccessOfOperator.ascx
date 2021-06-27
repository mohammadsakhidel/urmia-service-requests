<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccessOfOperator.ascx.cs" Inherits="Views_Shared_AccessOfOperator" %>

<table border="0" cellpadding="0" cellspacing="0" class="form">
    <tr>
        <td class="form_right">
            مدیریت کاربران :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Users" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            پیشنهادات و انتقادات :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Suggestions" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            نظرسنجی :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Polls" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            مسابقه :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Competitions" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            ارسال پیامک :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_SendSms" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            آمار و گزارشات :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Reports" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            سرویس ها :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Services" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تنظیمات :
        </td>
        <td class="form_left">
            <asp:DropDownList ID="cmb_Settings" runat="server" CssClass="combobox" Width="120px">
                <asp:ListItem Text="خواندن" Value="1"></asp:ListItem>
                <asp:ListItem Text="خواندن و نوشتن" Value="2"></asp:ListItem>
                <asp:ListItem Text="پنهان" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
    <tr>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" ValidationGroup="AccessRules" OnClick="LinkButton1_Click"></asp:LinkButton>
        </td>
    </tr>
</table>