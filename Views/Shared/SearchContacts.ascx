<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchContacts.ascx.cs" Inherits="Views_Shared_SearchContacts" %>

<div class="advance_search">

    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="Up_BookSelector">
        <ProgressTemplate>
            <div class="overload">
                <div class="loading_large center"></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                دفترچه تلفن :
            </td>
            <td>
                فیلد :
            </td>
            <td>
                شرط :
            </td>
            <td>
                مقدار :
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="Up_BookSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Books" runat="server" CssClass="combobox" 
                            Width="150px" AutoPostBack="true" 
                            OnSelectedIndexChanged="cmb_Books_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_FieldSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Fields" runat="server" CssClass="combobox" Width="130px" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:DropDownList ID="cmb_Condition" runat="server" CssClass="combobox" Width="120px">
                    <asp:ListItem Text="مساوی باشد با" Value="1"></asp:ListItem>
                    <asp:ListItem Text="مشابه باشد با" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tb_Value" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_AddCondition" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_add_item" 
                            onclick="LinkButton1_Click"></asp:LinkButton>
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