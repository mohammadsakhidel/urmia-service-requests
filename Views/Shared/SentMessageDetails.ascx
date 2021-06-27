<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SentMessageDetails.ascx.cs" Inherits="Views_Shared_SentMessageDetails" %>

<div class="subject">
    متن پیامک :
</div>

<div style="margin-top : 5px; line-height : 20px;">
    <asp:Label ID="lbl_SmsText" runat="server" Text=""></asp:Label>
</div>

<div class="subject" style="margin-top : 5px;">
    لیست دریافت کنندگان پیامک :
</div>

<div style="margin-top : 10px;">

    <asp:GridView ID="grid_items" runat="server" AllowPaging="true" Width="350px"
        PageSize="20" CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
        OnRowCreated="grid_items_RowCreated" AllowSorting="false" 
        onpageindexchanging="grid_items_PageIndexChanging">
        <HeaderStyle CssClass="grid_header" />
        <Columns>
            <asp:TemplateField HeaderText="شماره موبایل دریافت کننده پیامک" ItemStyle-CssClass="grid_item">
                <ItemTemplate>
                    <%# Eval("MobNumber")%>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</div>