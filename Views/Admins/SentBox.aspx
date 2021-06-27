<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="SentBox.aspx.cs" Inherits="Views_Admins_SentBox" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SentBox.ascx" TagPrefix="uc" TagName="SentBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/SentBox.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>
    
    <div class="content">
        
        <uc:PageTitle runat="server" Text="صندوق پیامک های ارسال شده" />

        <div style="margin-top : 10px;">

            <uc:SentBox runat="server" ID="uc_SentBox"/>

        </div>

    </div>

</asp:Content>