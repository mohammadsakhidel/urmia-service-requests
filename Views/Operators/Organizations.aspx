<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="Organizations.aspx.cs" Inherits="Views_Operators_Organizations" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Organizations.ascx" TagPrefix="uc" TagName="Organizations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
        
        <uc:PageTitle runat="server" Text="مدیریت کاربران » سازمان ها"/>

        <div style="margin-top : 10px;">
        
            <uc:Organizations runat="server" ID="uc_Organizations"/>
        
        </div>

    </div>
</asp:Content>

