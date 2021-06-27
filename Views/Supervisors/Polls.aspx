<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/SupervisorPanel.master" AutoEventWireup="true" CodeFile="Polls.aspx.cs" Inherits="Views_Supervisors_Polls" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/Polls.ascx" TagPrefix="uc" TagName="PollsModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_organpanel_main" Runat="Server">
    
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>
    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="نظرسنجی » لیست نظرسنجی ها"/>
        
        <div style="margin : 10px 0 10px 0;">

            <uc:PollsModule ID="uc_Polls" runat="server" />

        </div>
    
    </div>

</asp:Content>

