<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportForMayer.ascx.cs" Inherits="Views_Shared_ReportForMayer" %>

<table border="0" cellpadding="0" cellspacing="0" class="form">
    <tr>
        <td class="form_right">
            انتخاب ماه :
        </td>
        <td class="form_left">
            <table border="0" cellpadding="2" cellspacing="0">
                <tr>
                    <td>
                        <asp:DropDownList ID="cmb_Month" runat="server" Width="100px" CssClass="combobox">
                            <asp:ListItem Text="فروردین" Value="1"></asp:ListItem>
                            <asp:ListItem Text="اردیبهشت" Value="2"></asp:ListItem>
                            <asp:ListItem Text="خرداد" Value="3"></asp:ListItem>
                            <asp:ListItem Text="تیر" Value="4"></asp:ListItem>
                            <asp:ListItem Text="مرداد" Value="5"></asp:ListItem>
                            <asp:ListItem Text="شهریور" Value="6"></asp:ListItem>
                            <asp:ListItem Text="مهر" Value="7"></asp:ListItem>
                            <asp:ListItem Text="آبان" Value="8"></asp:ListItem>
                            <asp:ListItem Text="آذر" Value="9"></asp:ListItem>
                            <asp:ListItem Text="دی" Value="10"></asp:ListItem>
                            <asp:ListItem Text="بهمن" Value="11"></asp:ListItem>
                            <asp:ListItem Text="اسفند" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmb_Year" runat="server" Width="70px" CssClass="combobox">
                            <asp:ListItem Text="1391" Value="1391"></asp:ListItem>
                            <asp:ListItem Text="1392" Value="1392"></asp:ListItem>
                            <asp:ListItem Text="1393" Value="1393"></asp:ListItem>
                            <asp:ListItem Text="1394" Value="1394"></asp:ListItem>
                            <asp:ListItem Text="1395" Value="1395"></asp:ListItem>
                            <asp:ListItem Text="1396" Value="1396"></asp:ListItem>
                            <asp:ListItem Text="1397" Value="1397"></asp:ListItem>
                            <asp:ListItem Text="1398" Value="1398"></asp:ListItem>
                            <asp:ListItem Text="1399" Value="1399"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_show" 
                            onclick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تعداد کل پیشنهادات :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_TotalSuggestionsCount" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            منتظر پاسخ :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_PendingsCount" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            رسیدگی شده :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_VerifiedsCount" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            رد شده :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_RejectedsCount" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            بیشترین ارجاع :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_MaxRoutings" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            بیشترین پیام منتظر پاسخ :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_MaxPendings" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            بیشترین پیام رسیدگی شده :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_MaxVerified" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>