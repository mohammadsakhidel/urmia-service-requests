<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="RoutedSuggestions.aspx.cs" Inherits="Views_Admins_RoutedSuggestions" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SuggestionRoutings.ascx" TagPrefix="uc" TagName="SuggestionRoutings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/RoutedSuggestions.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">

        <uc:PageTitle runat="server" Text="پیشنهادات و انتقادات » صندوق سازمان"/>

        <div style="margin-top : 10px;">

            <div class="grid_filters">
                <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>
                            سازمان :
                        </td>
                        <td class="td_pad1">
                            <asp:DropDownList ID="cmb_Organization" runat="server" CssClass="combobox_lowpad" Width="180px" AutoPostBack="true" onselectedindexchanged="cmb_Organization_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td style="padding-right : 30px;">
                            وضعیت :
                        </td>
                        <td class="td_pad1">
                            <asp:DropDownList ID="cmb_Status" runat="server" CssClass="combobox_lowpad" 
                                Width="100px" AutoPostBack="true" 
                                onselectedindexchanged="cmb_Status_SelectedIndexChanged">
                                <asp:ListItem Text="همه" Value="0"></asp:ListItem>
                                <asp:ListItem Text="منتظر پاسخ" Value="1"></asp:ListItem>
                                <asp:ListItem Text="رد شده" Value="2"></asp:ListItem>
                                <asp:ListItem Text="رسیدگی شده" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        
        </div>

        <uc:SuggestionRoutings runat="server" ID="uc_SuggestionRoutings"/>

    </div>

</asp:Content>

