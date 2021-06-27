<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="NewContactBook.aspx.cs" Inherits="Views_Operators_ToolWindows_NewContactBook" %>

<%@ Register Src="~/Views/Shared/ContactBookEditor.ascx" TagName="ContactBookEditor" TagPrefix="uc" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagName="PageTitle" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="ایجاد دفترچه تلفن جدید"/>

    <div style="margin-top : 10px;">
    
        <uc:ContactBookEditor runat="server" ID="uc_ContactBookEditor" />
    
    </div>

</asp:Content>

