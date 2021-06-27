<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="EditOperator.aspx.cs" Inherits="Views_Admins_ToolWindows_NewOperator" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/OperatorEditor.ascx" TagPrefix="uc" TagName="OperatorEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <uc:PageTitle runat="server" Text="ویرایش اپراتور شبکه"/>

    <div style="margin-top : 10px;">
    
        <uc:OperatorEditor runat="server" ID="uc_OperatorEditor" Action="edit"/>
    
    </div>

</asp:Content>

