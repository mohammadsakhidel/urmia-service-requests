<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Competition.ascx.cs" Inherits="Views_Shared_Competition" %>

<asp:Panel ID="pnl_ActiveCompetition" runat="server">

    <asp:Panel ID="pnl_chart" runat="server" Visible="false">

        <div style="margin-top : 20px;">
            <asp:Label ID="lbl_comp_subject" runat="server" Text="" CssClass="subject"></asp:Label>
        </div>

        <asp:Chart ID="ch_CompResult" runat="server" Width="600px" Height="400px">
            <Series>
                <asp:Series Name="ch_CompResult_Series" YValueType="Int32"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ch_CompResult_Area" BackColor="#f6f6f6">
                    <Area3DStyle Enable3D="true" Inclination="20" LightStyle="Realistic" WallWidth="15" Perspective="0" PointGapDepth="0" PointDepth="40"/>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <table border="0" cellpadding="3" cellspacing="0" class="center resume">
            <tr>
                <td align="left">
                    <span class="resume_label">
                        تعداد کل پاسخ ها :
                    </span>
                </td>
                <td align="right">
                    <asp:Label ID="lbl_total_votes" runat="server" Text="" CssClass="resume_value"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <span class="resume_label">
                        زمان آغاز :
                    </span>
                </td>
                <td align="right">
                    <asp:Label ID="lbl_date_of_create" runat="server" Text="" CssClass="resume_value"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <span class="resume_label">
                        زمان پایان :
                    </span>
                </td>
                <td align="right">
                    <asp:Label ID="lbl_date_of_expire" runat="server" Text="" CssClass="resume_value"></asp:Label>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnl_list" runat="server" Visible="false">

        <div style="margin-top : 20px;">
            <asp:Label ID="lbl_comp_subject2" runat="server" Text="" CssClass="subject"></asp:Label>
        </div>

        <div class="list_header" style="margin : 10px 0 5px 0;">
            <table border="0" cellpadding="3" cellspacing="0">
                <tr>
                    <td>
                        نمایش
                    </td>
                    <td>
                        <asp:DropDownList ID="cmb_PageSize" runat="server" CssClass="combobox" 
                            Width="60px" AutoPostBack="true" 
                            onselectedindexchanged="cmb_PageSize_SelectedIndexChanged">
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        پاسخ در هر صفحه
                    </td>
                </tr>
            </table>
        </div>

        <asp:DataList ID="list_Answers" runat="server" Width="100%">
            <ItemTemplate>
                <div class="list_item">
                    <div class="list_item_info">
                        <%# Eval("RecievedMessage.Citizen.MobNumber") %>  
                        در
                        <%# Eval("RecievedMessage.DateOfRecieveText")%>    
                    </div>
                    <div class="list_item_text" style="margin-top : 5px;">
                        <%# Eval("Answer") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

        <asp:Panel ID="pnl_pager" runat="server" CssClass="pager">
            <asp:HiddenField ID="hid_CompetitionID" runat="server" Value="0" />
            <asp:HiddenField ID="hid_PageIndex" runat="server" Value="0" />
            <asp:HiddenField ID="hid_PageSize" runat="server" Value="10" />
            <asp:HiddenField ID="hid_PagesCount" runat="server" Value="1" />

            <table border="0" cellpadding="0" cellspacing="0" class="center">
                <tr>
                    <td>
                        <asp:LinkButton ID="btn_Previous" runat="server" CssClass="pager_previous" 
                            onclick="btn_Previous_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lbl_PagerText" runat="server" Text="" CssClass="pager_text"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="btn_Next" runat="server" CssClass="pager_next" 
                            onclick="btn_Next_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>

        </asp:Panel>

    </asp:Panel>

</asp:Panel>

<asp:Panel ID="pnl_no_item" runat="server" CssClass="no_items" Visible="false">
    <table>
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