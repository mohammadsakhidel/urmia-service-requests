<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/PrintPortrait.master" AutoEventWireup="true" CodeFile="PrintMessages.aspx.cs" Inherits="Views_Operators_PrintMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="print_title">
        <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
    </div>
    <div>
        
        <asp:GridView ID="grid_items" runat="server" Width="100%"
            CssClass="grid_print" GridLines="Both" AutoGenerateColumns="false" 
            OnRowCreated="grid_items_RowCreated" AllowSorting="false">
            <HeaderStyle CssClass="grid_header_print" />
            <Columns>

                <asp:TemplateField HeaderText="متن پیامک" ItemStyle-CssClass="grid_item" ItemStyle-Width="45%">
                    <ItemTemplate>
                        <%# Eval("Text") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="فرستنده" ItemStyle-CssClass="grid_item" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <%# Eval("Citizen.MobNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="زمان ارسال" ItemStyle-CssClass="grid_item" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <%# Eval("DateOfRecieveShortText")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="نتیجه پردازش" ItemStyle-CssClass="grid_item" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <%# Eval("ProcessResultText")%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

