﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportOfSuggestions.ascx.cs" Inherits="Views_Shared_ReportOfSuggestions" %>
<%@ Register Src="~/Views/Shared/SearchSuggestion.ascx" TagPrefix="uc" TagName="SearchSuggestion" %>

<uc:SearchSuggestion runat="server" ID="uc_SearchSuggestion"/>

<div style="margin-top : 10px;">
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn_search" OnClick="LinkButton2_Click"></asp:LinkButton>
</div>

<div style="margin-top : 10px;">

    <asp:Panel ID="pnl_items" runat="server" Visible="false">

        <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
            CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
            PageSize="20" OnRowCreated="grid_items_RowCreated" 
            OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false">
            <HeaderStyle CssClass="grid_header" />
            <Columns>

                <asp:TemplateField HeaderText="متن پیشنهاد" ItemStyle-CssClass="grid_item" ItemStyle-Width="40%">
                    <ItemTemplate>
                        <%# Eval("RecievedMessage.Text") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="فرستنده" ItemStyle-CssClass="grid_item" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <%# Eval("RecievedMessage.Citizen.MobNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="زمان ارسال" ItemStyle-CssClass="grid_item" ItemStyle-Width="17%">
                    <ItemTemplate>
                        <%# Eval("RecievedMessage.DateOfRecieveShortText")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ارجاعات" ItemStyle-CssClass="grid_item" ItemStyle-Width="8%">
                    <ItemTemplate>
                        <%# Eval("SuggestionRoutings.Count")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="کد رهگیری" ItemStyle-CssClass="grid_item" ItemStyle-Width="13%">
                    <ItemTemplate>
                        <%# Eval("PersuitCode") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item" ItemStyle-Width="7%">
                    <ItemTemplate>
                        <%# Eval("HtmlOfDetails")%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <div class="grid_tools" style="margin-top : 5px;">
            <table border="0" cellpadding="3" cellspacing="0">
                <tr>
                    <td>
                        عنوان گزارش :
                    </td>
                    <td>
                        <asp:TextBox ID="tb_Title" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_print" 
                            onclick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>

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