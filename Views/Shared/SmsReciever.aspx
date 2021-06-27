<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/Main.master" AutoEventWireup="true" CodeFile="SmsReciever.aspx.cs" Inherits="Views_Shared_SmsReciever" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" Runat="Server">

    <div class="content">

        <asp:Label ID="lblTester" runat="server" Text="" Font-Size="Large" ForeColor="Orange" Font-Bold="true"></asp:Label>

        <asp:Panel ID="pnl_errors" runat="server">
        </asp:Panel>

    </div>

</asp:Content>

