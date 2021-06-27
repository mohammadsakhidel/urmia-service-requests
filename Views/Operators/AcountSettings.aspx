<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/OperatorPanel.master" AutoEventWireup="true" CodeFile="AcountSettings.aspx.cs" Inherits="Views_Operators_AcountSettings" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/PasswordChange.ascx" TagPrefix="uc" TagName="PasswordChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_operatorpanel_main" Runat="Server">

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="تنظیمات حساب کاربری" />

        <div style="margin-top : 15px;">

            <uc:PasswordChange runat="server" ID="uc_PasswordChange"/>

        </div>
    
    </div>

</asp:Content>

