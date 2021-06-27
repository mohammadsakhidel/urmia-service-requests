<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="DetailsOfContactBook.aspx.cs" Inherits="Views_Admins_ToolWindows_DetailsOfContactBook" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ContactBookDetails.ascx" TagPrefix="uc" TagName="ContactBookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">
    
    <uc:PageTitle runat="server" Text="لیست مخاطبین دفترچه تلفن"/>

    <div style="margin-top : 10px;">
    
        <uc:ContactBookDetails runat="server" ID="uc_ContactBookDetails"/>
    
    </div>

</asp:Content>

