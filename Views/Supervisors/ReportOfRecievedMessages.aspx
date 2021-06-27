<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/SupervisorPanel.master" AutoEventWireup="true" CodeFile="ReportOfRecievedMessages.aspx.cs" Inherits="Views_Supervisors_ReportOfRecievedMessages" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ReportOfRecievedMessages.ascx" TagPrefix="uc" TagName="ReportOfRecievedMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="گزارشات » گزارش پیامک های دریافتی"/>

        <div style="margin-top : 10px;">
        
            <uc:ReportOfRecievedMessages runat="server" ID="uc_ReportOfRecievedMessages"/>
        
        </div>
    
    </div>

</asp:Content>

