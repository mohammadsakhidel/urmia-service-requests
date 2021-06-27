<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactBookEditor.ascx.cs" Inherits="Views_Shared_ContactBookEditor" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="up_Form" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table border="0" cellpadding="3" cellspacing="0">
            <tr>
                <td align="left">
                    نام دفترچه تلفن :
                </td>
                <td>
                    <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_Name" ValidationGroup="SaveBook"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn_save" ValidationGroup="SaveBook" OnClick="LinkButton2_Click"></asp:LinkButton>
                </td>
                <td>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <div class="loading"></div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top : 10px; padding-bottom : 10px;">
                    <div class="subject">فیلدهای مخاطبین :</div>
                </td>
            </tr>
            <tr>
                <td align="left">
                    عنوان فیلد :
                </td>
                <td>
                    <asp:TextBox ID="tb_FieldName" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_FieldName" ValidationGroup="AddContact"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    شناسه فیلد :
                </td>
                <td>
                    <asp:TextBox ID="tb_FieldIdentifier" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="validator" ControlToValidate="tb_FieldIdentifier" ValidationGroup="AddContact"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_add" OnClick="LinkButton1_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="up_Fields" runat="server">
    <ContentTemplate>
        <div style="margin-top : 10px;">
        
            <asp:GridView ID="grid_items" runat="server" Width="100%" AllowPaging="false"
                CssClass="grid" GridLines="None" AutoGenerateColumns="false" 
                OnRowCreated="grid_items_RowCreated" AllowSorting="false" OnRowCommand="grid_items_RowCommand">
                <HeaderStyle CssClass="grid_header" />
                <Columns>
                    <asp:TemplateField HeaderText="عنوان فیلد" ItemStyle-CssClass="grid_item">
                        <ItemTemplate>
                            <%# Eval("Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="شناسه فیلد" ItemStyle-CssClass="grid_item">
                        <ItemTemplate>
                            <%# Eval("Identifier")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="grid_item">
                        <ItemTemplate>
                            
                            <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid_button grid_delete" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف" OnClientClick="return confirm('آیا اطمینان دارید؟');"></asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
        </div>
    </ContentTemplate>
</asp:UpdatePanel>