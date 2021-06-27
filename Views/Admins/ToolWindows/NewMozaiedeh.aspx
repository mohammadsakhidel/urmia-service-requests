<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="NewMozaiedeh.aspx.cs" Inherits="Views_Admins_ToolWindows_NewMozaiedeh" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/MozaiedehEditor.ascx" TagPrefix="uc" TagName="MozaiedehEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">
    <uc:PageTitle runat="server" Text="مزایده جدید"/>
    <div style="margin-top : 10px;">
        <uc:MozaiedehEditor runat="server" ID="uc_MozaiedehEditor"/>
    </div>
</asp:Content>

