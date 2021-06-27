<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="EditMonagheseh.aspx.cs" Inherits="Views_Operators_ToolWindows_EditMonagheseh" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/MonaghesehEditor.ascx" TagPrefix="uc" TagName="MonaghesehEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">
    <uc:PageTitle ID="PageTitle1" runat="server" Text="ویرایش مناقصه"/>
    <div style="margin-top : 10px;">
        <uc:MonaghesehEditor runat="server" ID="uc_MonaghesehEditor"/>
    </div>
</asp:Content>

