<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/SupervisorPanel.master" AutoEventWireup="true" CodeFile="ReportOfSuggestions.aspx.cs" Inherits="Views_Supervisors_ReportOfSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ReportOfSuggestions.ascx" TagPrefix="uc" TagName="ReportOfSuggestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="گزارشات » گزارش پیشنهادات و انتقادات"/>

        <div style="margin-top : 10px;">
        
            <uc:ReportOfSuggestions runat="server" ID="uc_ReportOfSuggestions" />
        
        </div>
    
    </div>

</asp:Content>

