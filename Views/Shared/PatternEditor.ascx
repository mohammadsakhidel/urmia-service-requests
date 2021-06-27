<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PatternEditor.ascx.cs" Inherits="Views_Shared_PatternEditor" %>

<script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/jquery-1.4.1.js") %>'></script>
<script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/PatternEditor.js") %>'></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td align="left">
            عنوان الگو :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_Name" ValidationGroup="SavePattern"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" style="padding-top : 10px;">
            متن الگو :
        </td>
        <td align="right">
            <asp:TextBox ID="tb_Text" runat="server" CssClass="textbox" Width="300px" Height="80px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" 
            CssClass="validator" ControlToValidate="tb_Text" ValidationGroup="SavePattern"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" class="center">
    <tr>
        <td>
            <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" 
                        ValidationGroup="SavePattern" onclick="LinkButton1_Click" ></asp:LinkButton>
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