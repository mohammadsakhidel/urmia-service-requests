<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuggestionInfo.ascx.cs" Inherits="Views_Shared_SuggestionInfo" %>

<asp:Panel runat="server">

    <div class="subject">
        مشخصات :
    </div>

    <div style="margin-top : 10px;" class="list_item">
        <div class="list_item_info">
            <asp:Label ID="lbl_info" runat="server" Text=""></asp:Label>
        </div>
        <div class="list_item_info" style="margin-top : 5px;">
            <asp:Label ID="lbl_persuitCode" runat="server" Text=""></asp:Label>
        </div>
        <div class="list_item_text" style="margin-top : 5px;">
            <asp:Label ID="lbl_text" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <% if (HttpContext.Current.User.IsInRole(MyRoles.Administrator) || HttpContext.Current.User.IsInRole(MyRoles.Operator) || HttpContext.Current.User.IsInRole(MyRoles.Mayor))
       { %>

    <div style="margin-top : 10px;" class="subject">
        لیست ارجاعات پیشنهاد :
    </div>

    <asp:Panel ID="pnl_listOfRoutings" runat="server">
        <asp:Panel ID="pnl_routings" runat="server"></asp:Panel>
        <div class="suggestion_colors" style="margin-top : 5px;"></div>
    </asp:Panel>

    <% } %>

</asp:Panel>
