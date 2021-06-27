<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/AdminPanel.master" AutoEventWireup="true" CodeFile="SuggestionsTrash.aspx.cs" Inherits="Views_Admins_SuggestionsTrash" %>

<%@ Register Src="~/Views/Shared/PageTitle.ascx" TagPrefix="uc" TagName="PageTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_adminpanel_main" Runat="Server">

    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/Admins/SuggestionsTrash.js") %>'></script>
    <script type="text/javascript" src='<%= MyHelper.Url("~/Scripts/MyHelper.js") %>'></script>

    <div class="content">

        <uc:PageTitle ID="PageTitle1" runat="server" Text="پیشنهادات و انتقادات » بازیافت"/>

        <div style="margin-top : 10px;">
        
            <div class="grid_filters">
                <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>
                            نوع :
                        </td>
                        <td class="td_pad1">
                            <asp:DropDownList ID="cmb_Type" runat="server" CssClass="combobox_lowpad" 
                                Width="200px" AutoPostBack="true" 
                                OnSelectedIndexChanged="cmb_Type_SelectedIndexChanged">
                            
                                <asp:ListItem Text="حذف شده از صندوق سازمان ها" Value="1"></asp:ListItem>
                                <asp:ListItem Text="حذف شده از صندوق پیشنهادات هدایت نشده" Value="2"></asp:ListItem>
                            
                            </asp:DropDownList>
                            <asp:HiddenField ID="hid_Type" runat="server" Value="1"/>
                        </td>
                    </tr>
                </table>
            </div>

            <asp:Panel ID="pnl_routed_items" runat="server">

                <asp:GridView ID="grid_routed_items" runat="server" Width="100%" AllowPaging="true"
                    CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
                    PageSize="15" OnRowCreated="grid_routed_items_RowCreated" 
                    OnPageIndexChanging="grid_routed_items_PageIndexChanging" AllowSorting="false" 
                    OnRowCommand="grid_routed_items_RowCommand">
                    <HeaderStyle CssClass="grid_header" />
                    <Columns>

                        <asp:TemplateField HeaderText="متن پیشنهاد" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <span title='<%# Eval("Suggestion.RecievedMessage.Text") %>'><%# Eval("Suggestion.RecievedMessage.CutedText")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="سازمان" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <%# Eval("Organization.Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="فرستنده" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <%# Eval("Suggestion.RecievedMessage.Citizen.MobNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="تاریخ ارسال" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <%# Eval("Suggestion.RecievedMessage.DateOfRecieveShortText")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="وضعیت" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <%# Eval("StatusText")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>

                                <%# Eval("HtmlOfTrashActions") %>

                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="grid_button grid_restore" style="margin-right : 3px;"
                                    CommandName="RestoreItem" CommandArgument='<%# Eval("ID") %>' ToolTip="بازیابی" 
                                    OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                                <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" style="margin-right : 3px;" 
                                    CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف دائم" 
                                    OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>

                <div class="suggestion_colors" style="margin-top : 5px;"></div>

            </asp:Panel>

            <asp:Panel ID="pnl_notRouted_items" runat="server">

                <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="true"
                    CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
                    PageSize="15" OnRowCreated="grid_items_RowCreated" OnRowCommand="grid_items_RowCommand"
                    OnPageIndexChanging="grid_items_PageIndexChanging" AllowSorting="false">
                    <HeaderStyle CssClass="grid_header" />
                    <Columns>

                        <asp:TemplateField HeaderText="متن پیشنهاد" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <span title='<%# Eval("RecievedMessage.Text") %>'><%# Eval("RecievedMessage.CutedText")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="فرستنده" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <%# Eval("RecievedMessage.Citizen.MobNumber")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="تاریخ ارسال" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>
                                <%# Eval("RecievedMessage.DateOfRecieveShortText")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item">
                            <ItemTemplate>

                                <%# Eval("HtmlOfTrashActions")%>

                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="grid_button grid_restore" style="margin-right : 3px;"
                                    CommandName="RestoreItem" CommandArgument='<%# Eval("ID") %>' ToolTip="بازیابی" 
                                    OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                                <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" style="margin-right : 3px;"
                                    CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف دائم" 
                                    OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>

            </asp:Panel>

            <asp:Panel ID="pnl_no_item" runat="server" CssClass="no_items" Visible="false">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div class="small_icon error_icon"></div>
                        </td>
                        <td class="td_pad1">
                            موردی جهت نمایش وجود ندارد.
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        
        </div>

    </div>

</asp:Content>

