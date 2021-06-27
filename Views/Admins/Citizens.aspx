<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Citizens.aspx.cs" Inherits="Views_Admins_Citizens" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Citizens.ascx" TagPrefix="uc" TagName="Citizens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Citizens.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="content">
    
        <uc:PageTitle runat="server" Text="مدیریت کاربران » شهروندان"/>

        <div style="margin-top : 10px;">
        
            <uc:Citizens runat="server" ID="uc_Citizens"/>
        
        </div>
    
    </div>

</asp:Content>

