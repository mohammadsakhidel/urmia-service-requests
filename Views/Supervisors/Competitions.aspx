<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/SupervisorPanel.master" AutoEventWireup="true" CodeFile="Competitions.aspx.cs" Inherits="Views_Supervisors_Competitions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Competitions.ascx" TagPrefix="uc" TagName="CompetitionsModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="مسابقه » لیست مسابقه ها"/>
        
        <div style="margin : 10px 0 10px 0;">

            <uc:CompetitionsModule runat="server" ID="uc_Competitions"/>

        </div>
    
    </div>

</asp:Content>

