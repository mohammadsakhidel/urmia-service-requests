<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="RouteSuggestion.aspx.cs" Inherits="Views_Admins_ToolWindows_RouteSuggestion" %>

<%@ Register Src="~/Views/Shared/RouteSuggestion.ascx" TagPrefix="uc" TagName="RouteSuggestion" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="هدایت پیشنهاد به سازمان"/>

    <div style="margin-top : 10px;">
    
        <uc:RouteSuggestion runat="server" ID="uc_RouteSuggestion"/>
    
    </div>

</asp:Content>

