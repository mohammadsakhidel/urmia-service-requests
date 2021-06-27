<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuggestionRoutings.ascx.cs" Inherits="Views_Shared_SuggestionRoutings" %>

<asp:Panel ID="pnl_items" runat="server">

    <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
        CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
        PageSize="15" OnRowCreated="grid_items_RowCreated" 
        OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false" 
        OnRowCommand="grid_items_RowCommand">
        <HeaderStyle CssClass="grid_header" />
        <Columns>

            <asp:TemplateField HeaderText="متن پیشنهاد" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <span title='<%# Eval("Suggestion.RecievedMessage.Text") %>'><%# Eval("Suggestion.RecievedMessage.CutedText")%></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="سازمان" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("Organization.Name")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="فرستنده" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("Suggestion.RecievedMessage.Citizen.MobNumber")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="تاریخ ارسال" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("Suggestion.RecievedMessage.DateOfRecieveShortText")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="وضعیت" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("StatusText")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item">
                <ItemTemplate>

                    <%# Eval("HtmlOfGridActions") %>

                    <% if (Permissions.SuggestionsDeletePermission)
                       { %>

                        <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف" OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                    <% } %>

                </ItemTemplate>
            </asp:TemplateField>
                        
        </Columns>
    </asp:GridView>

    <div class="suggestion_colors" style="margin-top : 5px;"></div>

</asp:Panel>

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
