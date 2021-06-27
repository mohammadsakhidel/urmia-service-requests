<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contacts.ascx.cs" Inherits="Views_Shared_Contacts" %>

<% if (Permissions.SendSmsWritePermission)
   { %>

    <div class="grid_tools" style="margin : 10px 0 10px 0;">
        <a class="btn_new" href='<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewContactBook.aspx") %>' onclick="return Open('<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewContactBook.aspx") %>', '', 700, 500);"></a>
    </div>

<% } %>

<asp:Panel ID="pnl_items" runat="server">

    <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
        CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
        PageSize="15" OnRowCreated="grid_items_RowCreated" 
        OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false" 
        OnRowCommand="grid_items_RowCommand">
        <HeaderStyle CssClass="grid_header" />
        <Columns>

            <asp:TemplateField HeaderText="نام دفترچه" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("Name") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="تاریخ ایجاد" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("DateOfCreateText")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="تعداد مخاطبین" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("Contacts.Count")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item">
                <ItemTemplate>

                    <%# Eval("HtmlOfGridActions")%>

                    <% if (Permissions.SendSmsWritePermission)
                       { %>

                        <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" style="margin-right : 3px;" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف" OnClientClick="return confirm('آیا اطمینان دارید؟');">
                        </asp:LinkButton>

                    <% } %>

                </ItemTemplate>
            </asp:TemplateField>
                        
        </Columns>
    </asp:GridView>

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