<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Supervisors.ascx.cs" Inherits="Views_Shared_Supervisors" %>

<% if (Permissions.UsersWritePermission)
   { %>

<div class="grid_tools">
    <a class="btn_new" href='<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewSupervisor.aspx") %>' onclick="return Open('<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewSupervisor.aspx") %>', '', 600, 350);"></a>
</div>

<% } %>

<asp:Panel ID="pnl_items" runat="server" style="margin-top : 10px;">

    <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
        CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
        PageSize="15" OnRowCreated="grid_items_RowCreated" 
        OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false" 
        OnRowCommand="grid_items_RowCommand">
        <HeaderStyle CssClass="grid_header" />
        <Columns>
                    
            <asp:TemplateField ItemStyle-CssClass="grid_item" HeaderText="فعال">
                <ItemTemplate>

                    <% if (Permissions.UsersWritePermission)
                       { %>

                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="grid_checkbox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("IsApproved") %>'/>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>'/>

                    <% } %>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="نام" DataField="Name" ItemStyle-CssClass="grid_item" SortExpression="Name"/>
            <asp:BoundField HeaderText="سمت" DataField="Position" ItemStyle-CssClass="grid_item" SortExpression="Name"/>
            <asp:BoundField HeaderText="نام کاربری" DataField="UserName" ItemStyle-CssClass="grid_item" SortExpression="Name"/>
            <asp:BoundField HeaderText="تاریخ عضویت" DataField="DateOfCreateText" ItemStyle-CssClass="grid_item" SortExpression="DateOfCreate"/>
            <asp:BoundField HeaderText="ایجاد شده توسط" DataField="CreatedBy" ItemStyle-CssClass="grid_item" SortExpression="CreatedBy"/>
            <asp:TemplateField ItemStyle-CssClass="grid_item">
                <ItemTemplate>

                    <% if (Permissions.UsersWritePermission)
                       { %>

                        <%# Eval("HtmlOfEditButton") %>
                        <span style="margin-right : 5px;"><asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف" OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton></span>

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