<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Monaghesat.ascx.cs" Inherits="Views_Shared_Monaghesat" %>

<% if (Permissions.ServicesWritePermission) {%>

<div class="grid_tools" style="margin-bottom : 10px;">
    <a class="btn_new" href='<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewMonaghese.aspx") %>' onclick="return Open('<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewMonaghese.aspx") %>', '', 550, 350);"></a>
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
            <asp:TemplateField HeaderText="شماره" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("Shomare")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <span title='<%# Eval("Name")%>'><%# Eval("CutedName")%></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تاریخ آغاز" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("DateOfStartText")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تاریخ پایان" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("DateOfEndText")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ایجاد شده توسط" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("CreatedBy")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="grid_item">
                <ItemTemplate>

                    <% if (Permissions.ServicesWritePermission) {%>

                        <%# Eval("HtmlOfGridActions")%>
                        <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" style="margin-right : 5px;" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف" OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                    <% } %>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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