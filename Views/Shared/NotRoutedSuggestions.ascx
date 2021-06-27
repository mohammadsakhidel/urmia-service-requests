<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NotRoutedSuggestions.ascx.cs" Inherits="Views_Shared_NotRoutedSuggestions" %>

<asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
    CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
    PageSize="15" OnRowCreated="grid_items_RowCreated" OnRowCommand="grid_items_RowCommand"
    OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false">
    <HeaderStyle CssClass="grid_header" />
    <Columns>

        <asp:TemplateField HeaderText="متن پیشنهاد" ItemStyle-CssClass="grid_item">
            <ItemTemplate>
                <span title='<%# Eval("RecievedMessage.Text") %>'><%# Eval("RecievedMessage.CutedText")%></span>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="فرستنده" ItemStyle-CssClass="grid_item">
            <ItemTemplate>
                <%# Eval("RecievedMessage.Citizen.MobNumber")%>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="تاریخ ارسال" ItemStyle-CssClass="grid_item">
            <ItemTemplate>
                <%# Eval("RecievedMessage.DateOfRecieveShortText")%>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item">
            <ItemTemplate>

                <% if (Permissions.SuggestionsWritePermission)
                   { %>

                <%# Eval("HtmlOfNotRoutedsGrid")%>

                <% } %>

                <% if (Permissions.SuggestionsDeletePermission)
                   { %>

                <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" 
                    CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف" 
                    OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                    <% } %>

            </ItemTemplate>
        </asp:TemplateField>
                        
    </Columns>
</asp:GridView>

<asp:Panel ID="pnl_no_item" runat="server" CssClass="no_items" Visible="false">
    <table border="0" cellpadding="0" cellspacing="0">
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