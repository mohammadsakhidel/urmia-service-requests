<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Views_Admins_Settings" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Settings.ascx" TagPrefix="uc" TagName="Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <div class="content">

        <uc:PageTitle runat="server" Text="تنظیمات سیستم" />

        <div style="margin-top : 10px;">
        
            <uc:Settings runat="server" ID="uc_Settings"/>
        
        </div>

    </div>

</asp:Content>

