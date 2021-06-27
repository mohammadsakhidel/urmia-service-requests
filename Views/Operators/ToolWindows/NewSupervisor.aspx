<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="NewSupervisor.aspx.cs" Inherits="Views_Operators_ToolWindows_NewSupervisor" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SupervisorEditor.ascx" TagPrefix="uc" TagName="SupervisorEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <uc:PageTitle runat="server" Text="تعریف ناظر شبکه جدید"/>

    <div style="margin-top : 10px;">
    
        <uc:SupervisorEditor runat="server" ID="uc_SupervisorEditor"/>
    
    </div>

</asp:Content>

