<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Monaghesat.aspx.cs" Inherits="Views_Admins_Monaghesat" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Monaghesat.ascx" TagPrefix="uc" TagName="Monaghesat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Monaghesat.js") %>'></script>

    <div class="content">
        
        <uc:PageTitle runat="server" Text="سرویس ها » مناقصات"/>
        
        <div style="margin-top : 10px;">
            
            <uc:Monaghesat ID="uc_Monaghesat" runat="server"/>

        </div>

    </div>

</asp:Content>

