<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Polls.ascx.cs" Inherits="Views_Shared_Polls" %>

<% if (Permissions.PollsWritePermission)
   {%>

<div class="grid_tools" style="margin-bottom : 10px;">
    <a class="btn_new" href='<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewPoll.aspx") %>' onclick="return Open('<%= MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/NewPoll.aspx") %>', '', 700, 450);"></a>
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
            <asp:TemplateField HeaderText="عنوان" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("CutedSubject")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="زمان آغاز" DataField="DateOfCreateText" ItemStyle-CssClass="grid_item" SortExpression="UserName"/>
            <asp:BoundField HeaderText="مدت اعتبار" DataField="DaysOfActivityText" ItemStyle-CssClass="grid_item" SortExpression="UserName"/>
            <asp:BoundField HeaderText="زمان پایان" DataField="DateOfExpireText" ItemStyle-CssClass="grid_item" SortExpression="UserName"/>
            <asp:BoundField HeaderText="ایجاد شده توسط" DataField="CreatedBy" ItemStyle-CssClass="grid_item" SortExpression="UserName"/>
            <asp:TemplateField ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("HtmlOfDetailsButton")%>

                    <% if (Permissions.SendSmsWritePermission)
                       { %>

                        <span style="margin-right : 5px;"><%# Eval("HtmlOfSendButton")%></span>

                    <% } %>

                    <% if (Permissions.PollsWritePermission)
                       { %>

                        <span style="margin-right : 5px;"><%# Eval("HtmlOfEditButton")%></span>
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