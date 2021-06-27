<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactBookDetails.ascx.cs" Inherits="Views_Shared_ContactBookDetails" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div class="subject" style="margin-bottom : 5px;">
    افزودن مخاطب جدید :
</div>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td>
            <asp:Panel ID="pnl_form" runat="server"></asp:Panel>
        </td>
        <td valign="bottom" style="padding : 0 0 5px 0;">
            <asp:UpdatePanel ID="Up_AddContact" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_add" OnClick="LinkButton1_Click"></asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="loading_container" valign="bottom" style="padding : 0 5px 10px 0;">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="Up_AddContact">
                <ProgressTemplate>
                    <div class="loading"></div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </td>
    </tr>
</table>

<div class="subject" style="margin-bottom : 5px;">
    لیست مخاطبین :
</div>

<asp:UpdatePanel ID="up_Contacts" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnl_contacts" runat="server">
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:Panel ID="pnl_no_item" runat="server" CssClass="no_items" Visible="false">
    <table>
        <tr>
            <td>
                <div class="small_icon error_icon"></div>
            </td>
            <td class="td_pad1">
                موردی جهت نمایش وجود ندارد.
            </td>
        </tr>
    </table>
</asp:Panel>