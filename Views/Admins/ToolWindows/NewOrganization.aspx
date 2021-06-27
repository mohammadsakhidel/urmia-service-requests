<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="NewOrganization.aspx.cs" Inherits="Views_Admins_ToolWindows_EditOrganization" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/OrganEditor.ascx" TagPrefix="uc" TagName="OrganEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <asp:ScriptManager runat="server">
    </asp:ScriptManager>

    <uc:PageTitle runat="server" Text="تعریف سازمان جدید"/>

    <div style="margin : 10px 30px 10px 0;">
    
        <uc:OrganEditor runat="server" ID="uc_OrganEditor" />
    
    </div>

</asp:Content>

