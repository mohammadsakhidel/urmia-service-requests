<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendModule.ascx.cs" Inherits="Views_Shared_SendModule" %>
<%@ Register Src="~/Views/Shared/SearchCitizen.ascx" TagPrefix="uc" TagName="SearchCitizen" %>
<%@ Register Src="~/Views/Shared/SearchContacts.ascx" TagPrefix="uc" TagName="SearchContacts" %>

<script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/SendSMSModule.js") %>'></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td align="left" valign="top" style="padding-top : 10px;">
            متن پیام :
        </td>
        <td align="right">
            <div style="position : relative; display : inline-block;">
                <asp:TextBox ID="tb_Text" runat="server" CssClass="textbox" Width="350px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                <div class="sms_info">
                    <span id="lbl_sms_length">0/0</span>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" style="padding-top : 10px; position : relative;">
            شماره ها :
        </td>
        <td align="right">
            <div style="position : relative; display : inline-block;">
                <asp:UpdatePanel ID="up_Numbers" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="tb_Numbers" runat="server" CssClass="textbox" Width="350px" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        <div class="sms_info">
                            <asp:Label ID="lbl_lines_count" runat="server" Text="0"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </td>
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="up_clear_numbers" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_clear_numbers" runat="server" CssClass="btn_clear_numbers" 
                                    OnClick="LinkButton3_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="loading_container">
                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="up_clear_numbers">
                            <ProgressTemplate>
                                <div class="loading"></div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top : 5px;">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="up_load_citizen_numbers" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_citizen_numbers" runat="server" CssClass="btn_citizen_numbers" OnClick="LinkButton2_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="loading_container">
                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="up_load_citizen_numbers">
                            <ProgressTemplate>
                                <div class="loading"></div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
            <asp:LinkButton ID="btn_book_numbers" CssClass="btn_book_numbers" style="margin-top : 5px;" runat="server" OnClientClick="return false;"></asp:LinkButton>
            <div id="div_book_selector" style="margin-top : 10px;" class="hide">
                <asp:UpdatePanel ID="up_BookSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Book" runat="server" CssClass="combobox" 
                            Width="180px" AutoPostBack="true" 
                            OnSelectedIndexChanged="cmb_Book_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="margin-top : 10px;">
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="up_BookSelector">
                        <ProgressTemplate>
                            <div class="loading"></div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
        </td>
    </tr>
</table>

<asp:Panel ID="pnl_CitizensAdvancedSearch" runat="server">
    <div>
        <a id="btn_citizens_advanced_search" class="link">» جستجوی پیشرفته شهروندان</a>
    </div>
    <div id="div_citizens_advanced_search" class="hide" style="margin-top : 5px;">
        <uc:SearchCitizen runat="server" ID="uc_SearchCitizen"/>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:UpdatePanel ID="Up_AddCitizenNumbers" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn_add" 
                                style="margin-top : 5px;" OnClick="LinkButton2_Click1"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td_pad1">
                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="Up_AddCitizenNumbers">
                        <ProgressTemplate>
                            <div class="loading"></div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

<asp:Panel ID="pnl_ContactsAdvancedSearch" runat="server">
    <div style="margin-top : 10px;" >
        <a id="btn_books_advanced_search" class="link">» جستجوی پیشرفته مخاطبین</a>
    </div>
    <div id="div_books_advanced_search" class="hide" style="margin-top : 5px;">
        <uc:SearchContacts runat="server" ID="uc_SearchContacts"/>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn_add" 
                                style="margin-top : 5px;" OnClick="LinkButton3_Click1"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="td_pad1">
                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="Up_AddCitizenNumbers">
                        <ProgressTemplate>
                            <div class="loading"></div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

<table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
    <tr>
        <td>
            <asp:UpdatePanel ID="up_send" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_send" 
                        OnClick="LinkButton1_Click" OnClientClick="show_loading();"></asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="loading_container">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_send">
                <ProgressTemplate>
                    <div class="loading"></div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </td>
    </tr>
</table>

<asp:UpdatePanel ID="up_Message" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div style="margin-top : 10px; text-align : center;">
            <asp:Label ID="lbl_wait" runat="server" Text="" CssClass="center waiting hide"></asp:Label>
            <asp:Panel ID="pnl_Message" runat="server" Width="250px" CssClass="hide">
                <asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
