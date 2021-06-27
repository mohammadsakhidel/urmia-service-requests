<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="DetailsOfCompetition.aspx.cs" Inherits="Views_Operators_ToolWindows_DetailsOfCompetition" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Competition.ascx" TagPrefix="uc" TagName="Competition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle ID="PageTitle1" runat="server" Text="مسابقه » جزئیات مسابقه"/>

    <div style="margin-top : 10px;">
            
        <uc:Competition ID="uc_Competition" runat="server" ChartWidth="600" ChartHeight="290"/>

    </div>

</asp:Content>

