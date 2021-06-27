<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="RejectSuggestion.aspx.cs" Inherits="Views_Admins_ToolWindows_RejectSuggestion" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/RejectSuggestion.ascx" TagPrefix="uc" TagName="RejectSuggestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle ID="PageTitle1" runat="server" Text="رد پیشنهاد"/>
    
    <div style="margin-top : 10px;">
    
        <uc:RejectSuggestion runat="server" ID="uc_RejectSuggestion"/>

    </div>

</asp:Content>

