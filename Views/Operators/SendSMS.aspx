<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="SendSMS.aspx.cs" Inherits="Views_Operators_SendSMS" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SendModule.ascx" TagPrefix="uc" TagName="SendModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/SendSMS.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        <uc:PageTitle runat="server" Text="ارسال پیامک"/>

        <div style="margin-top : 10px;">
        
            <uc:SendModule ID="uc_SendModule" runat="server" Type="Free" DefaultText=""/>
        
        </div>
    </div>

</asp:Content>

