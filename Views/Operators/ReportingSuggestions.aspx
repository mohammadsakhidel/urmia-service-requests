<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="ReportingSuggestions.aspx.cs" Inherits="Views_Operators_ReportingSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ReportOfSuggestions.ascx" TagPrefix="uc" TagName="ReportOfSuggestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="گزارشات » گزارش پیشنهادات و انتقادات"/>

        <div style="margin-top : 10px;">
        
            <uc:ReportOfSuggestions runat="server" ID="uc_ReportOfSuggestions"/>
        
        </div>
    
    </div>

</asp:Content>

