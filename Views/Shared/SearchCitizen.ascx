<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchCitizen.ascx.cs" Inherits="Views_Shared_SearchCitizen" %>

<%@ Register Src="~/Views/Shared/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>

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
                            Width="180px" AutoPostBack="true" 
                            onselectedindexchanged="cmb_Fields_SelectedIndexChanged">
                            <asp:ListItem Text="شماره موبایل" Value="1"></asp:ListItem>
                            <asp:ListItem Text="نام شهروند" Value="2"></asp:ListItem>
                            <asp:ListItem Text="جنسیت" Value="3"></asp:ListItem>
                            <asp:ListItem Text="سال تولد" Value="4"></asp:ListItem>
                            <asp:ListItem Text="شغل" Value="5"></asp:ListItem>
                            <asp:ListItem Text="منطقه شهرداری" Value="6"></asp:ListItem>
                            <asp:ListItem Text="آدرس" Value="7"></asp:ListItem>
                            <asp:ListItem Text="تاریخ اولین ارتباط" Value="8"></asp:ListItem>
                            <asp:ListItem Text="تعداد پیام های ارسال کرده" Value="9"></asp:ListItem>
                            <asp:ListItem Text="تعداد پیشنهادات" Value="10"></asp:ListItem>
                            <asp:ListItem Text="تعداد نظرسنجی های شرکت کرده" Value="11"></asp:ListItem>
                            <asp:ListItem Text="تعداد مسابقه های شرکت کرده" Value="12"></asp:ListItem>
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
                        <asp:TextBox ID="tb_Value" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                        <uc:DateSelector runat="server" ID="uc_DateSelector" YearMinMax="1391;1400" Visible="false"/>
                        <asp:DropDownList ID="cmb_Value" runat="server" CssClass="combobox" Width="150px" AutoPostBack="true" Visible="false">
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
                    OnRowCommand="grid_conditions_RowCommand">
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