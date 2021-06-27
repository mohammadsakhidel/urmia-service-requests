<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="Patterns.aspx.cs" Inherits="Views_Operators_Patterns" %>

<%@ Register Src="~/Views/Shared/Patterns.ascx" TagPrefix="uc" TagName="Patterns" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">

        <uc:PageTitle runat="server" Text="ارسال پیامک » الگوهای آماده"/>

        <div style="margin-top : 10px;">
        
            <uc:Patterns runat="server" ID="uc_Patterns"/>
        
        </div>

    </div>

</asp:Content>

