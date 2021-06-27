<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="EditPattern.aspx.cs" Inherits="Views_Operators_ToolWindows_NewPattern" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/PatternEditor.ascx" TagPrefix="uc" TagName="PatternEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="ویرایش الگوی" />

    <div style="margin-top : 10px;">
    
        <uc:PatternEditor runat="server" ID="uc_PatternEditor"/>
    
    </div>

</asp:Content>

