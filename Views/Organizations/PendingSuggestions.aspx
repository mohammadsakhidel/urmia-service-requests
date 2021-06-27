<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OrganPanel.master" AutoEventWireup="true" CodeFile="PendingSuggestions.aspx.cs" Inherits="Views_Organizations_PendingSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SuggestionRoutings.ascx" TagPrefix="uc" TagName="SuggestionRoutings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="پیشنهادات و انتقادات » پیشنهادات منتظر پاسخ"/>

        <div style="margin-top : 10px;">
        
            <uc:SuggestionRoutings runat="server" ID="uc_SuggestionRoutings" Role="3"/>
        
        </div>
    
    </div>

</asp:Content>

