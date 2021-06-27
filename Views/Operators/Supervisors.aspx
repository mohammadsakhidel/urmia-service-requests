<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="Supervisors.aspx.cs" Inherits="Views_Operators_Supervisors" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Supervisors.ascx" TagPrefix="uc" TagName="Supervisors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle runat="server" Text="مدیریت کاربران » ناظرین شبکه"/>

        <div style="margin-top : 10px;">
        
            <uc:Supervisors runat="server" ID="uc_Supervisors"/>
        
        </div>
    
    </div>

</asp:Content>

