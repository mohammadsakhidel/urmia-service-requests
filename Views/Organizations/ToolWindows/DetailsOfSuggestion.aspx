<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="DetailsOfSuggestion.aspx.cs" Inherits="Views_Organizations_ToolWindows_DetailsOfSuggestion" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SuggestionInfo.ascx" TagPrefix="uc" TagName="SuggestionInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="جزئیات پیشنهاد" />

    <div style="margin-top : 10px;">

        <uc:SuggestionInfo runat="server" ID="uc_SuggestionInfo"/>

    </div>

</asp:Content>

