<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OrganPanel.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Views_Organizations_Charts" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/ChartsOfOrganization.ascx" TagPrefix="uc" TagName="ChartsOfOrganization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">
        
        <uc:PageTitle ID="PageTitle1" runat="server" Text="آمار و گزارشات » گزارشات نموداری"/>

        <div style="margin-top : 10px;">
            
            <uc:ChartsOfOrganization runat="server" ID="uc_ChartsOfOrganization"/>

        </div>

    </div>

</asp:Content>

