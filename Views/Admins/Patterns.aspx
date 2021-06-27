<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Patterns.aspx.cs" Inherits="Views_Admins_Patterns" %>

<%@ Register Src="~/Views/Shared/Patterns.ascx" TagPrefix="uc" TagName="Patterns" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Patterns.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">

        <uc:PageTitle runat="server" Text="ارسال پیامک » الگوهای آماده"/>

        <div style="margin-top : 10px;">
        
            <uc:Patterns runat="server" ID="uc_Patterns"/>
        
        </div>

    </div>

</asp:Content>

