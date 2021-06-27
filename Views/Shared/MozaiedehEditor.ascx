<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MozaiedehEditor.ascx.cs" Inherits="Views_Shared_MozaiedehEditor" %>
<%@ Register Src="~/Views/Shared/DateSelector.ascx" TagPrefix="uc" TagName="Date" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td>
            شماره مزایده :
        </td>
        <td>
            <asp:TextBox ID="tb_Shomare" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_Shomare"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            عنوان :
        </td>
        <td>
            <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_Name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            تاریخ شروع :
        </td>
        <td>
            <uc:Date runat="server" YearMinMax="1391;1400" ID="uc_DateOfStart" EnableValidation="true"/>
        </td>
    </tr>
    <tr>
        <td>
            تاریخ پایان :
        </td>
        <td>
            <uc:Date runat="server" YearMinMax="1391;1400" ID="uc_DateOfEnd" EnableValidation="true"/>
        </td>
    </tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
    <tr>
        <td>
            <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" OnClick="LinkButton1_Click"></asp:LinkButton>
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