<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="NotRoutedSuggestions.aspx.cs" Inherits="Views_Admins_NotRoutedSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/NotRoutedSuggestions.ascx" TagPrefix="uc" TagName="NotRoutedSuggestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/NotRoutedSuggestions.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        <uc:PageTitle runat="server" Text="پیشنهادات و انتقادات » صندوق پیشنهادات هدایت نشده"/>

        <div style="margin-top : 10px;">
            <uc:NotRoutedSuggestions runat="server" ID="uc_NotRoutedSuggestions"/>
        </div>
    </div>

</asp:Content>

