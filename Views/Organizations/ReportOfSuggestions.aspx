<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OrganPanel.master" AutoEventWireup="true" CodeFile="ReportOfSuggestions.aspx.cs" Inherits="Views_Organizations_ReportOfSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ReportOfSuggestions.ascx" TagPrefix="uc" TagName="ReportOfSuggestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">
        
        <uc:PageTitle runat="server" Text="آمار و گزارشات » گزارش پیشنهادات و انتقادات"/>

        <div style="margin-top : 10px;">
            
            <uc:ReportOfSuggestions runat="server" ID="uc_ReportOfSuggestions" TypeOfSearch="Organization"/>

        </div>

    </div>

</asp:Content>

