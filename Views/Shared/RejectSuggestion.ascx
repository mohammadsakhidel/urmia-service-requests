<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RejectSuggestion.ascx.cs" Inherits="Views_Shared_RejectSuggestion" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:HiddenField ID="hid_RoutingId" runat="server" />

<div class="subject">
    مشخصات :
</div>

<div style="margin-top : 10px;" class="list_item">
    <div class="list_item_info">
        <asp:Label ID="lbl_info" runat="server" Text=""></asp:Label>
    </div>
    <div class="list_item_info" style="margin-top : 5px;">
        <asp:Label ID="lbl_persuitCode" runat="server" Text=""></asp:Label>
    </div>
    <div class="list_item_text" style="margin-top : 5px;">
        <asp:Label ID="lbl_text" runat="server" Text=""></asp:Label>
    </div>
</div>

<div class="subject" style="margin-top : 10px;">
    شرح دلایل رد پیشنهاد :
</div>

<div style="margin-top : 10px;">
    <asp:TextBox ID="tb_Explanation" runat="server" TextMode="MultiLine" Width="500px" Height="80px" CssClass="textbox"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="reject" CssClass="validator" ControlToValidate="tb_Explanation"></asp:RequiredFieldValidator>
</div>

<table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
    <tr>
        <td>
            <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" 
                        ValidationGroup="reject" OnClick="LinkButton1_Click"></asp:LinkButton>
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