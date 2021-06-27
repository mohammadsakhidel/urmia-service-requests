<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompetitionEditor.ascx.cs" Inherits="Views_Shared_CompetitionEditor" %>

<%@ Register Src="~/Views/Shared/Keywords.ascx" TagPrefix="uc" TagName="Keywords" %>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td align="left">
            عنوان مسابقه :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Subject" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Subject" ValidationGroup="fillform"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" style="padding-top : 10px;">
            متن پیامک :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Text" runat="server" Width="300px" Height="70px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Text" ValidationGroup="fillform"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left">
            مدت اعتبار :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Days" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
            روز
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Days" ValidationGroup="fillform"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left">
            نوع مسابقه :
        </td>
        <td align="right">
            <asp:DropDownList ID="cmb_Type" runat="server" CssClass="combobox" style="width : 100px;">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Text="چند گزینه ای" Value="1"></asp:ListItem>
                <asp:ListItem Text="تشریحی" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="cmb_Type" ValidationGroup="fillform"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" style="padding-top : 10px;">
            گزینه ها :
        </td>
        <td align="right">
            <uc:Keywords runat="server" ID="uc_Options" ItemWidth="250px" RepeatColumns="1" Text=""/>
        </td>
    </tr>
</table>