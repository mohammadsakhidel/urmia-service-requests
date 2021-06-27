<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="ActiveCompetition.aspx.cs" Inherits="Views_Admins_ActiveCompetition" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Competition.ascx" TagPrefix="uc" TagName="Competition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/ActiveCompetition.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        
        <uc:PageTitle ID="PageTitle1" runat="server" Text="مسابقه » مسابقه فعال"/>

        <div style="margin-top : 10px;">
            
            <uc:Competition ID="uc_ActiveCompetition" runat="server" ChartWidth="600" ChartHeight="400"/>

        </div>

    </div>

</asp:Content>

