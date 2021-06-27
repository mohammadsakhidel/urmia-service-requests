<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="AccessOfOperator.aspx.cs" Inherits="Views_Admins_ToolWindows_AccessOfOrganization" %>
<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/AccessOfOperator.ascx" TagPrefix="uc" TagName="AccessOfOperator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">
    <uc:PageTitle ID="PageTitle1" runat="server" Text="سطح دسترسی اپراتور شبکه"/>

    <div style="margin-top : 10px;">
        
        <uc:AccessOfOperator runat="server" ID="uc_AccessOfOperator"/>
        
    </div>
</asp:Content>

