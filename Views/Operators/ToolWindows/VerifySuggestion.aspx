<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="VerifySuggestion.aspx.cs" Inherits="Views_Operators_ToolWindows_VerifySuggestion" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/VerifySuggestion.ascx" TagPrefix="uc" TagName="VerifySuggestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="اعلام رسیدگی به پیشنهاد"/>
    
    <div style="margin-top : 10px;">
    
        <uc:VerifySuggestion runat="server" ID="uc_VerifySuggestion"/>

    </div>

</asp:Content>

