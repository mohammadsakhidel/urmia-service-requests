<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrganEditor.ascx.cs" Inherits="Views_Shared_OrganEditor" %>

<%@ Register Src="~/Views/Shared/Keywords.ascx" TagName="Keywords" TagPrefix="uc" %>


<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td align="left">
            نام سازمان :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Name" runat="server" Width="180" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Name" ValidationGroup="organ"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left">
            نام کاربری :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_UserName" runat="server" Width="130" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_UserName" ValidationGroup="organ"></asp:RequiredFieldValidator>
            <span class="small_text">حداقل 8 کاراکتر از حروف [a - z] یا [A - Z] و اعداد</span>
        </td>
    </tr>
    <tr>
        <td align="left">
            کلمه رمز :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Password" runat="server" Width="130" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_Password" ValidationGroup="organ"></asp:RequiredFieldValidator>
            <span class="small_text">حداقل 6 کاراکتر از حروف [a - z] یا [A - Z] و اعداد</span>
        </td>
    </tr>
    <tr>
        <td align="left">
            تکرار کلمه رمز :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_PasswordConfirm" runat="server" Width="130" CssClass="textbox"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_PasswordConfirm" ControlToCompare="tb_Password" ValidationGroup="organ"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" CssClass="validator" 
                ControlToValidate="tb_PasswordConfirm" ValidationGroup="organ"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left">
            شماره های اطلاع رسانی :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_CellPhones" runat="server" Width="250" CssClass="textbox" ></asp:TextBox>
            <span class="small_text">با ; جدا شوند</span>
        </td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="right" style="padding : 10px 0 10px 0;">
            <asp:CheckBox ID="ch_ViewUnroutedSuggestions" runat="server" Checked="false" Text="مشاهده پیشنهادات هدایت نشده"/>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" style=" padding-top : 10px;">
            کلمات کلیدی :
        </td>
        <td align="right">
            <uc:Keywords runat="server" ID="uc_Keywords" ItemWidth="120px" RepeatColumns="3" Text=""/>
        </td>
    </tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" class="center">
    <tr>
        <td>
            <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" ValidationGroup="organ" OnClick="LinkButton1_Click"></asp:LinkButton>
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