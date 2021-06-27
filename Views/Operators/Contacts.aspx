<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Views_Operators_Contacts" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Contacts.ascx" TagPrefix="uc" TagName="Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        <uc:PageTitle runat="server" Text="ارسال پیامک » دفترچه تلفن"/>

        <div style="margin-top : 10px;">
        
            <uc:Contacts runat="server" ID="uc_Contacts"/>
        
        </div>
    </div>
</asp:Content>

