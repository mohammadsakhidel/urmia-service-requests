<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/MayorPanel.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Views_Mayor_Charts" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Charts.ascx" TagPrefix="uc" TagName="Charts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_mayorpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/Charts.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle runat="server" Text="گزارشات » گزارشات نموداری"/>

        <div style="margin-top : 10px;">

            <uc:Charts runat="server" ID="uc_Charts" />

        </div>
    
    </div>

</asp:Content>

