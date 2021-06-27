<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="DetailsOfCitizen.aspx.cs" Inherits="Views_Admins_ToolWindows_DetailsOfCitizen" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/CitizenDetails.ascx" TagPrefix="uc" TagName="CitizenDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="مدیریت کاربران » پرونده شهروند"/>

    <div style="margin-top : 10px;">
        
        <uc:CitizenDetails runat="server" ID="uc_CitizenDetails"/>

    </div>

</asp:Content>

