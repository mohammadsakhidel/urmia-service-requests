<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/MayorPanel.master" AutoEventWireup="true" CodeFile="OutOfDateSuggestions.aspx.cs" Inherits="Views_Mayor_OutOfDateSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/OutOfDateSuggestions.ascx" TagPrefix="uc" TagName="OutOfDateSuggestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_mayorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle runat="server" Text="پیشنهادات و انتقادات » پیشنهادات تاریخ گذشته" />

        <div style="margin-top : 10px;">
        
            <uc:OutOfDateSuggestions runat="server" ID="uc_OutOfDateSuggestions"/>
        
        </div>
    
    </div>

</asp:Content>

