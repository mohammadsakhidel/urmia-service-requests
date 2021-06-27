<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PasswordChange.ascx.cs" Inherits="Views_Shared_PasswordChange" %>

<table border="0" cellpadding="0" cellspacing="0" class="form">
    <tr>
        <td class="form_right">
            نام کاربری :
        </td>
        <td class="form_left" style="padding : 15px 10px 15px 15px;">
            <asp:Label ID="lbl_UserNumber" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            کلمه رمز :
        </td>
        <td class="form_left">
            <asp:TextBox ID="tb_Password" runat="server" CssClass="textbox" Width="200px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tb_Password" runat="server" ErrorMessage="*" CssClass="validator" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form_right">
            تکرار کلمه رمز :
        </td>
        <td class="form_left">
            <asp:TextBox ID="tb_Confirm" runat="server" CssClass="textbox" Width="200px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tb_Confirm" runat="server" ErrorMessage="*" CssClass="validator" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_Confirm" ControlToCompare="tb_Password" ValidationGroup="ChangePassword"></asp:CompareValidator>
        </td>
    </tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
    <tr>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" 
                OnClick="LinkButton1_Click" ValidationGroup="ChangePassword"></asp:LinkButton>
        </td>
    </tr>
</table>