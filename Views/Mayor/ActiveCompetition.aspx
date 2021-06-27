<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/MayorPanel.master" AutoEventWireup="true" CodeFile="ActiveCompetition.aspx.cs" Inherits="Views_Mayor_ActiveCompetition" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Competition.ascx" TagPrefix="uc" TagName="Competition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_mayorpanel_main" Runat="Server">

    <div class="content">
        
        <uc:PageTitle ID="PageTitle1" runat="server" Text="مسابقه » مسابقه فعال"/>

        <div style="margin-top : 10px;">
            
            <uc:Competition ID="uc_ActiveCompetition" runat="server" ChartWidth="600" ChartHeight="400"/>

        </div>

    </div>

</asp:Content>

