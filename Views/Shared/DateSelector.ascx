<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateSelector.ascx.cs" Inherits="Views_Shared_DateSelector" %>

<div style="display : inline;">
    <table border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td>
                <asp:DropDownList ID="cmb_Day" runat="server" CssClass="combobox" Width="60">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmb_Month" runat="server" CssClass="combobox" Width="100">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Text="فروردین" Value="1"></asp:ListItem>
                    <asp:ListItem Text="اردیبهشت" Value="2"></asp:ListItem>
                    <asp:ListItem Text="خرداد" Value="3"></asp:ListItem>
                    <asp:ListItem Text="تیر" Value="4"></asp:ListItem>
                    <asp:ListItem Text="مرداد" Value="5"></asp:ListItem>
                    <asp:ListItem Text="شهریور" Value="6"></asp:ListItem>
                    <asp:ListItem Text="مهر" Value="7"></asp:ListItem>
                    <asp:ListItem Text="آبان" Value="8"></asp:ListItem>
                    <asp:ListItem Text="آذر" Value="9"></asp:ListItem>
                    <asp:ListItem Text="دی" Value="10"></asp:ListItem>
                    <asp:ListItem Text="بهمن" Value="11"></asp:ListItem>
                    <asp:ListItem Text="اسفند" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmb_Year" runat="server" CssClass="combobox" Width="80">
                </asp:DropDownList>
            </td>
            <td>
                <% if (EnableValidation)
                   {%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cmb_Day" runat="server" ErrorMessage="*" CssClass="validator"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="cmb_Month" runat="server" ErrorMessage="*" CssClass="validator"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="cmb_Year" runat="server" ErrorMessage="*" CssClass="validator"></asp:RequiredFieldValidator>
                <% } %>
            </td>
        </tr>
    </table>
</div>