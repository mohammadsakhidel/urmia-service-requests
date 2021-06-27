<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/SupervisorPanel.master" AutoEventWireup="true" CodeFile="ActivePoll.aspx.cs" Inherits="Views_Supervisors_ActivePoll" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Poll.ascx" TagPrefix="uc" TagName="PollResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">

    <div class="content">
        
        <uc:PageTitle ID="PageTitle1" runat="server" Text="نظرسنجی » نظرسنجی فعال"/>

        <div style="margin-top : 10px;">
            
            <uc:PollResult ID="uc_ActivePoll" runat="server" ChartWidth="600" ChartHeight="400"/>

        </div>

    </div>

</asp:Content>

