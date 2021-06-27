<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" Runat="Server">
    <div style="padding : 50px;">
        <table border="0" cellpadding="0" cellspacing="0" class="center">
            <tr>
                <td colspan="3">
                    <div class="explanation" style="padding-bottom : 7px;">
                        جهت دسترسی به پانل کاربری خود، با نام کاربری و کلمه رمز خود وارد سیستم شوید.
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="login_header"></div>
                </td>
                <td class="login_content">
                    <asp:Login ID="Login1" runat="server"
                        FailureText="نام کاربری یا رمز عبور اشتباه است" LoginButtonText="" 
                        Orientation="Horizontal" PasswordLabelText="کلمه رمز :" 
                        PasswordRequiredErrorMessage="کلمه رمز را وارد نمایید." 
                        RememberMeText="مرا به خاطر بسپار" TextLayout="TextOnTop" TitleText="" 
                        UserNameLabelText="نام کاربری :" 
                        UserNameRequiredErrorMessage="نام کاربری را وارد نمایید." 
                        LoginButtonType="Button" onloggedin="Login1_LoggedIn">
                        <FailureTextStyle CssClass="login_validator" />
                        <LoginButtonStyle CssClass="login_button" />
                        <TextBoxStyle CssClass="textbox" />
                        <ValidatorTextStyle CssClass="login_validator" />
                    </asp:Login>
                </td>
                <td>
                    <div class="login_left"></div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

