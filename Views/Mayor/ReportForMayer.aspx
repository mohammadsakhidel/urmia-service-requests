<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/MayorPanel.master" AutoEventWireup="true" CodeFile="ReportForMayer.aspx.cs" Inherits="Views_Mayor_ReportForMayer" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ReportForMayer.ascx" TagPrefix="uc" TagName="ReportForMayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_mayorpanel_main" Runat="Server">

    <div class="content">
    
        <uc:PageTitle runat="server" Text="گزارشات » عملکرد ماهانه سازمان ها"/>

        <div style="margin-top : 10px;">
        
            <uc:ReportForMayer runat="server" ID="uc_ReportForMayer"/>
        
        </div>
    
    </div>

</asp:Content>

