<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/PrintPortrait.master" AutoEventWireup="true" CodeFile="PrintSuggestions.aspx.cs" Inherits="Views_Supervisors_PrintSuggestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="print_title">
        <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
            CssClass="grid_print" GridLines="None" AutoGenerateColumns="false" 
            OnRowCreated="grid_items_RowCreated" AllowSorting="false">
            <HeaderStyle CssClass="grid_header_print" />
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

                <asp:TemplateField HeaderText="زمان ارسال" ItemStyle-CssClass="grid_item" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <%# Eval("RecievedMessage.DateOfRecieveShortText")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ارجاعات" ItemStyle-CssClass="grid_item" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <%# Eval("SuggestionRoutings.Count")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="کد رهگیری" ItemStyle-CssClass="grid_item" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <%# Eval("PersuitCode") %>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

