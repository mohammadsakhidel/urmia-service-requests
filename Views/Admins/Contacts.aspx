<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Views_Admins_Contacts" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Contacts.ascx" TagPrefix="uc" TagName="Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Contacts.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        <uc:PageTitle runat="server" Text="ارسال پیامک » دفترچه تلفن"/>

        <div style="margin-top : 10px;">
        
            <uc:Contacts runat="server" ID="uc_Contacts"/>
        
        </div>
    </div>
</asp:Content>

