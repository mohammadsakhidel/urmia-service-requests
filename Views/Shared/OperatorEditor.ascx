<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OperatorEditor.ascx.cs" Inherits="Views_Shared_OperatorEditor" %>

<table border="0" cellpadding="3" cellspacing="0" style="margin-right : 30px;">
    <tr>
        <td align="left">
            نام اپراتور :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Name" runat="server" Width="180" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Name" ValidationGroup="fillform"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left">
            نام کاربری :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_UserName" runat="server" Width="130" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_UserName" ValidationGroup="fillform"></asp:RequiredFieldValidator>
            <span class="small_text">حداقل 8 کاراکتر از حروف [a - z] یا [A - Z] و اعداد</span>
        </td>
    </tr>
    <tr>
        <td align="left">
            کلمه رمز :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Password" runat="server" Width="130" CssClass="textbox" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Password" ValidationGroup="fillform"></asp:RequiredFieldValidator>
            <span class="small_text">حداقل 6 کاراکتر از حروف [a - z] یا [A - Z] و اعداد</span>
        </td>
    </tr>
    <tr>
        <td align="left">
            تکرار کلمه رمز :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_PasswordConfirm" runat="server" Width="130" CssClass="textbox" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_PasswordConfirm" ControlToCompare="tb_Password" ValidationGroup="fillform"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_PasswordConfirm" ValidationGroup="fillform"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" class="center"  style="margin-top : 10px;">
    <tr>
        <td>
            <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" 
                        ValidationGroup="fillform" onclick="LinkButton1_Click"></asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="loading_container">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_save">
                <ProgressTemplate>
                    <div class="loading"></div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </td>
    </tr>
</table>