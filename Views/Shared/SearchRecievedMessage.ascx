<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchRecievedMessage.ascx.cs" Inherits="Views_Shared_SearchRecievedMessages" %>

<%@ Register Src="~/Views/Shared/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="advance_search">

    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="Up_FieldSelector">
        <ProgressTemplate>
            <div class="overload">
                <div class="loading_large center"></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="Up_FieldSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Fields" runat="server" CssClass="combobox" 
                            Width="180px" AutoPostBack="true" OnSelectedIndexChanged="cmb_Fields_SelectedIndexChanged">
                            <asp:ListItem Text="متن پیامک" Value="1"></asp:ListItem>
                            <asp:ListItem Text="تاریخ ارسال پیامک" Value="2"></asp:ListItem>
                            <asp:ListItem Text="نتیجه پردازش پیامک" Value="3"></asp:ListItem>
                            <asp:ListItem Text="شماره موبایل فرستنده" Value="4"></asp:ListItem>
                            <asp:ListItem Text="منطقه سکونت فرستنده" Value="5"></asp:ListItem>
                            <asp:ListItem Text="آدرس فرستنده" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_ConditionSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Condition" runat="server" CssClass="combobox" Width="120px">
                            <asp:ListItem Text="مساوی باشد با" Value="1"></asp:ListItem>
                            <asp:ListItem Text="مشابه باشد با" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_ValueEntering" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="tb_Text" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                        <uc:DateSelector runat="server" ID="uc_DateSelector" YearMinMax="1391;1400" Visible="false"/>
                        <asp:DropDownList ID="cmb_ProcessResult" runat="server" CssClass="combobox" Width="120px" Visible="false">
                            <asp:ListItem Text="پردازش نشده" Value="0"></asp:ListItem>
                            <asp:ListItem Text="فرمت اشتباه" Value="1"></asp:ListItem>
                            <asp:ListItem Text="پیشنهاد" Value="2"></asp:ListItem>
                            <asp:ListItem Text="عدم وجود نظرسنجی فعال" Value="3"></asp:ListItem>
                            <asp:ListItem Text="گزینه اشتباه نظرسنجی" Value="4"></asp:ListItem>
                            <asp:ListItem Text="نظر" Value="5"></asp:ListItem>
                            <asp:ListItem Text="عدم وجود مسابقه فعال" Value="6"></asp:ListItem>
                            <asp:ListItem Text="گزینه اشتباه مسابقه" Value="7"></asp:ListItem>
                            <asp:ListItem Text="پاسخ مسابقه" Value="8"></asp:ListItem>
                            <asp:ListItem Text="رهگیری پیشنهاد" Value="9"></asp:ListItem>
                            <asp:ListItem Text="کد رهگیری اشتباه" Value="10"></asp:ListItem>
                            <asp:ListItem Text="درخواست سرویس" Value="11"></asp:ListItem>
                            <asp:ListItem Text="کد سرویس اشتباه" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_AddCondition" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_add_item" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="Up_AddCondition">
                    <ProgressTemplate>
                        <div class="loading"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    
    <asp:UpdatePanel ID="Up_Conditions" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="grid_conditions" runat="server" AutoGenerateColumns="false" 
                    GridLines="None" HeaderStyle-Height="0px" Width="100%" 
                    onrowcommand="grid_conditions_RowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30%">
                            <ItemTemplate>
                                <div class="condition_item">
                                    <%# Eval("field_name") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30%">
                            <ItemTemplate>
                                <div class="condition_item">
                                    <%# Eval("condition_name") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30%">
                            <ItemTemplate>
                                <div class="condition_item">
                                    <%# Eval("value_name") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" CommandName="DeleteItem" CommandArgument='<%# Eval("id") %>' ToolTip="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</div>