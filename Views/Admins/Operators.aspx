<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="Operators.aspx.cs" Inherits="Views_Admins_Operators" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Operators.ascx" TagPrefix="uc" TagName="Operators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Operators.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        
        <uc:PageTitle runat="server" Text="مدیریت کاربران » اپراتورهای شبکه"/>

        <div style="margin : 10px;">
        
            <uc:Operators runat="server" ID="uc_Operators"/>
        
        </div>

    </div>

</asp:Content>

