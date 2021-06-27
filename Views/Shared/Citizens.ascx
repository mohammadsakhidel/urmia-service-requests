<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Citizens.ascx.cs" Inherits="Views_Shared_Citizens" %>
<%@ Register Src="~/Views/Shared/SearchCitizen.ascx" TagPrefix="uc" TagName="SearchCitizen" %>

<div style="margin-top : 10px;">
            
    <uc:SearchCitizen runat="server" ID="uc_SearchCitizen"/>

</div>

<div style="margin-top : 10px;">
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn_search" OnClick="LinkButton2_Click"></asp:LinkButton>
</div>

<div style="margin-top : 10px;">

    <asp:Panel ID="pnl_Items" runat="server">
                
        <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
            CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
            PageSize="15" OnRowCreated="grid_items_RowCreated" 
            OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false">
            <HeaderStyle CssClass="grid_header" />
            <Columns>
                <asp:BoundField HeaderText="شماره موبایل" DataField="MobNumber" ItemStyle-CssClass="grid_item"/>
                <asp:BoundField HeaderText="تاریخ اولین ارتباط" DataField="DateOfAddText" ItemStyle-CssClass="grid_item"/>
                <asp:BoundField HeaderText="جنسیت" DataField="GenderText" ItemStyle-CssClass="grid_item"/>
                <asp:TemplateField HeaderText="آدرس" ItemStyle-CssClass="grid_item">
                    <ItemTemplate>
                        <span title='<%# Eval("Address") %>'><%# Eval("CutedAddress") %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="grid_item">
                    <ItemTemplate>
                        <%# Eval("HtmlOfDetailsAction") %>
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

</div>