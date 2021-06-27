<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/Error.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Views_Shared_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="big_error_icon center"></div>

    <%= SystemInfo.ErrorMessage %>

</asp:Content>

