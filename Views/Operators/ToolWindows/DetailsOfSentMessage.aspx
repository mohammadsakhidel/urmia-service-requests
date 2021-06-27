<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="DetailsOfSentMessage.aspx.cs" Inherits="Views_Operators_ToolWindows_DetailsOfSentMessage" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SentMessageDetails.ascx" TagPrefix="uc" TagName="SentMessageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle runat="server" Text="جزئیات پیامک ارسال شده"/>

    <div style="margin-top : 10px;">
    
        <uc:SentMessageDetails runat="server" ID="uc_SentMessageDetails"/>
    
    </div>

</asp:Content>

