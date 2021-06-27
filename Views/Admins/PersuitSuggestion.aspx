<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="PersuitSuggestion.aspx.cs" Inherits="Views_Admins_PersuitSuggestion" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>
<%@ Register Src="~/Views/Shared/SuggestionInfo.ascx" TagPrefix="uc" TagName="SuggestionInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/PersuitSuggestion.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">
    
        <uc:PageTitle ID="PageTitle1" runat="server" Text="پیشنهادات و انتقادات » رهگیری پیشنهاد" />

        <div style="margin : 10px 0 10px 0;">
            <table border="0" cellpadding="3" cellspacing="0">
                <tr>
                    <td>
                        کد رهگیری :
                    </td>
                    <td>
                        <asp:TextBox ID="tb_persuitCode" runat="server" CssClass="textbox" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="persuit" CssClass="validator" ControlToValidate="tb_persuitCode"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_search" 
                            ValidationGroup="persuit" onclick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    
        <asp:Panel ID="pnl_FoundSuggestion" runat="server" Visible="false">
            <uc:SuggestionInfo runat="server" ID="uc_SuggestionInfo"/>
        </asp:Panel>

        <asp:Panel ID="pnl_no_item" runat="server" CssClass="no_items" Visible="false">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div class="small_icon error_icon"></div>
                    </td>
                    <td class="td_pad1">
                        موردی یافت نشد.
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </div>

</asp:Content>

