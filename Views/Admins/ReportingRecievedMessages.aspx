<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="ReportingRecievedMessages.aspx.cs" Inherits="Views_Admins_ReportingRecievedMessages" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ReportOfRecievedMessages.ascx" TagPrefix="uc" TagName="ReportOfRecievedMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/ReportOfRecievedMessages.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle runat="server" Text="گزارشات » گزارش پیامک های دریافتی"/>

        <div style="margin-top : 10px;">
        
            <uc:ReportOfRecievedMessages runat="server" ID="uc_ReportOfRecievedMessages"/>
        
        </div>
    
    </div>

</asp:Content>

