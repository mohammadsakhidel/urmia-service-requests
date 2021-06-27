<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CitizenDetails.ascx.cs" Inherits="Views_Shared_CitizenDetails" %>

<table border="0" cellpadding="0" cellspacing="0" class="form">
    <tr>
        <td class="form_right">
            شماره موبایل :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_MobNumber" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            زمان ایجاد پرونده :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_DateOfAdd" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            نام :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            جنسیت :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Gender" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            سال تولد :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_BornYear" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            شغل :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Job" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            منطقه شهرداری :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Zone" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            آدرس :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Address" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تعداد پیامک های ارسال کرده :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_SentMessages" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تعداد پیشنهادات :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Suggestions" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تعداد نظرسنجی های شرکت کرده :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Polls" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تعداد مسابقات شرکت کرده :
        </td>
        <td class="form_left">
            <asp:Label ID="lbl_Competitions" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>