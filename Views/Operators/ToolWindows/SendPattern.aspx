<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="SendPattern.aspx.cs" Inherits="Views_Operators_ToolWindows_SendSmsToContacts" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SendModule.ascx" TagPrefix="uc" TagName="SendModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/jquery-1.4.1.js") %>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle ID="PageTitle1" runat="server" Text="ارسال پیامک به مخاطبین"/>

    <div style="margin-top : 10px;">
        
        <uc:SendModule ID="uc_SendModule" runat="server" Type="ContactBook" DefaultText=""/>
        
    </div>

</asp:Content>

