<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/ToolWindow.master" AutoEventWireup="true" CodeFile="DetailsOfPoll.aspx.cs" Inherits="Views_Operators_ToolWindows_DetailsOfPoll" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Poll.ascx" TagPrefix="uc" TagName="PollResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_tool_header" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_tool_content" Runat="Server">

    <uc:PageTitle ID="PageTitle1" runat="server" Text="نظرسنجی » جزئیات نظرسنجی"/>

    <div style="margin-top : 10px;">
            
        <uc:PollResult ID="uc_Poll" runat="server" ChartWidth="600" ChartHeight="290"/>

    </div>

</asp:Content>

