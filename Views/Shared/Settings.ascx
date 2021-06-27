<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="Views_Shared_Settings" %>

<script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Settings.js") %>'></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div class="operation_header">

    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                نوع تنظیمات :
            </td>
            <td>
                <asp:DropDownList ID="cmb_SettingsType" runat="server" CssClass="combobox" 
                    Width="200px" AutoPostBack="true" 
                    onselectedindexchanged="cmb_SettingsType_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>تنظیمات پاسخ پیامک های دریافتی</asp:ListItem>
                    <asp:ListItem>تنظیمات اطلاع رسانی پیشنهادات</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>

</div>

<div class="operation_content">

    <asp:Panel ID="pnl_ResponseSettings" runat="server">

        <!-- ******************************************************* -->
        <div class="settings_item" style="padding-top : 0px;">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_PersuitCode" runat="server" Text="پاسخ به ثبت موفقیت آمیز پیشنهاد و ارسال کد رهگیری"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_PersuitCode" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_PersuitCode" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="small_text" style="padding-top : 2px;">
                + کد رهگیری : xxxxxxxx
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_CorrectPollAnswer" runat="server" Text="پاسخ به ثبت موفقیت آمیز رأی نظرسنجی"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_CorrectPollAnswer" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_CorrectPollAnswer" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_CorrectCompetitionAnswer" runat="server" Text="پاسخ به ثبت موفقیت آمیز پاسخ مسابقه"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_CorrectCompetitionAnswer" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_CorrectCompetitionAnswer" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_IncorrectFormat" runat="server" Text="پاسخ به پیامک با فرمت اشتباه"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_IncorrectFormat" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_IncorrectFormat" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_IncorrectPollOptionSelected" runat="server" Text="پاسخ به انتخاب گزینه اشتباه نظرسنجی" />
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_IncorrectPollOptionSelected" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_IncorrectPollOptionSelected" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_IncorrectCompetitionOptionSelected" runat="server" Text="پاسخ به انتخاب گزینه اشتباه مسابقه"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_IncorrectCompetitionOptionSelected" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_IncorrectCompetitionOptionSelected" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_NoActivePollExist" runat="server" Text="پاسخ به عدم وجود نظرسنجی فعال"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_NoActivePollExist" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_NoActivePollExist" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_NoActiveCompetitionExist" runat="server" Text="پاسخ به عدم وجود مسابقه فعال"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_NoActiveCompetitionExist" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_NoActiveCompetitionExist" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_IncorrectPersuitCode" runat="server" Text="پاسخ به ارسال کد رهگیری اشتباه"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_IncorrectPersuitCode" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_IncorrectPersuitCode" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_Monaghesat" runat="server" Text="پاسخ به درخواست مناقصات"/>
            </div>
            <div style="margin-top : 5px;">
                <asp:TextBox ID="tb_Monaghesat" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                <span class="small_text">لیست : --list--</span>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_Mozaiedat" runat="server" Text="پاسخ به درخواست مزایدات"/>
            </div>
            <div style="margin-top : 5px;">
                <asp:TextBox ID="tb_Mozaiedat" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                <span class="small_text">لیست : --list--</span>
            </div>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <div>
                <asp:CheckBox CssClass="checkbox" ID="ch_IncorrectServiceCode" runat="server" Text="پاسخ به ارسال کد سرویس اشتباه"/>
            </div>
            <div style="margin-top : 5px;">
                <div style="position : relative; display : inline-block;">
                    <asp:TextBox ID="tb_IncorrectServiceCode" runat="server" CssClass="textbox" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                    <div class="sms_info">
                        <asp:Label ID="lbl_IncorrectServiceCode" runat="server" Text="0/0"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!-- ******************************************************* -->

        <table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
            <tr>
                <td>
                    <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <% if (Permissions.SettingsWritePermission)
                               { %>

                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_save" OnClientClick="return hide_response_message();" OnClick="LinkButton1_Click"></asp:LinkButton>

                            <% } %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="loading_container">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_save">
                        <ProgressTemplate>
                            <div class="loading"></div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="up_response_message" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="msg_responseSettings" runat="server" CssClass="center" style="margin-top : 10px;" Visible="false">
                    <asp:Label ID="lbl_messageOfresponseSettings" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>

    <asp:Panel ID="pnl_InformSettings" runat="server" Visible="false">

        <!-- ******************************************************* -->
        <div class="settings_item" style="padding-top : 0px;">
            <asp:CheckBox ID="ch_InformRouting" runat="server" CssClass="checkbox" Text="اطلاع رسانی خودکار ارجاعات پیشنهاد به سازمان ها"/>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <asp:CheckBox ID="ch_InformRejection" runat="server" CssClass="checkbox" Text="اطلاع رسانی خودکار هنگام رد پیشنهاد از طرف سازمان ارجاعی"/>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <asp:CheckBox ID="ch_InformVerifying" runat="server" CssClass="checkbox" Text="اطلاع رسانی خودکار اقدامات انجام شده"/>
        </div>
        <!-- ******************************************************* -->
        <div class="settings_item">
            <asp:CheckBox ID="ch_InformOrganizationOperators" runat="server" CssClass="checkbox" Text="اطلاع رسانی خودکار اپراتورهای سازمان"/>
        </div>


        <table border="0" cellpadding="0" cellspacing="0" class="center" style="margin-top : 10px;">
            <tr>
                <td>
                    <asp:UpdatePanel ID="up_save_inform_settings" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <% if (Permissions.SettingsWritePermission)
                               { %>

                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn_save" OnClientClick="return hide_inform_message();" OnClick="LinkButton2_Click"></asp:LinkButton>

                            <% } %>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="loading_container">
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="up_save_inform_settings">
                        <ProgressTemplate>
                            <div class="loading"></div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="up_message_inform_settings" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnl_message_inform_settings" runat="server" CssClass="center" style="margin-top : 10px;" Visible="false">
                    <asp:Label ID="lbl_message_inform_settings" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>

</div>