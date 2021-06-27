<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Mozaiedat.aspx.cs" Inherits="Views_Admins_Mozaiedat" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Mozaiedat.ascx" TagPrefix="uc" TagName="Mozaiedat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Mozaiedat.js") %>'></script>

    <div class="content">
        
        <uc:PageTitle ID="PageTitle1" runat="server" Text="سرویس ها » مزایده ها"/>
        
        <div style="margin-top : 10px;">
            
            <uc:Mozaiedat runat="server" ID="uc_Mozaiedat"/>

        </div>

    </div>

</asp:Content>

