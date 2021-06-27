<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SentBox.ascx.cs" Inherits="Views_Shared_SentBox" %>

<asp:Panel ID="pnl_list" runat="server">

    <div class="list_header" style="margin-bottom : 5px;">
        <table border="0" cellpadding="3" cellspacing="0">
            <tr>
                <td>
                    نمایش
                </td>
                <td>
                    <asp:DropDownList ID="cmb_PageSize" runat="server" CssClass="combobox" 
                        Width="60px" AutoPostBack="true" 
                        OnSelectedIndexChanged="cmb_PageSize_SelectedIndexChanged">
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    پیامک در هر صفحه
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="list_messages" runat="server" Width="100%">
        <ItemTemplate>
            <div class="list_item">
                <div class="list_item_info">
                    در تاریخ
                    <%# Eval("DateOfSendText") %>
                    ارسال شده برای
                    <%# Eval("SentMessageRecievers.Count")%>
                    نفر
                </div>
                <div class="list_item_text" style="margin-top : 5px;">
                    <%# Eval("HtmlOfText") %>
                </div>
                <div class="list_item_tools" style="margin-top : 5px;">
                    <%# Eval("HtmlOfDetailsButton") %>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:Panel ID="pnl_pager" runat="server" CssClass="pager">

        <table border="0" cellpadding="0" cellspacing="0" class="center">
            <tr>
                <td>
                    <asp:LinkButton ID="btn_Previous" runat="server" CssClass="pager_previous" OnClick="btn_Previous_Click"></asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="lbl_PagerText" runat="server" Text="" CssClass="pager_text"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="btn_Next" runat="server" CssClass="pager_next" OnClick="btn_Next_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>

    </asp:Panel>

</asp:Panel>

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