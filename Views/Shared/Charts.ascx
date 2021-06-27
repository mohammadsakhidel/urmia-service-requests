<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Charts.ascx.cs" Inherits="Views_Shared_Charts" %>


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<div class="operation_header">

    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td>
                نوع گزارش :
            </td>
            <td>
                <asp:DropDownList ID="cmb_ChartType" runat="server" CssClass="combobox" Width="200px">
                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                    <asp:ListItem Text="وضعیت پیشنهادات" Value="1"></asp:ListItem>
                    <asp:ListItem Text="عملکرد سازمان" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_ShowChart" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_chart" OnClick="LinkButton1_Click" OnClientClick="return ready_for_showing_chart();"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</div>

<div class="operation_content">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="Up_ShowChart">
        <ProgressTemplate>
            <div class="loading_large center" style="margin-top : 50px; margin-bottom : 50px;"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:Panel ID="pnl_OrganSelector" runat="server" CssClass="hide">
        <asp:UpdatePanel ID="Up_OrganSelector" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <table border="0" cellpadding="3" cellspacing="0" class="center">
                        <tr>
                            <td>
                                سازمان :
                            </td>
                            <td>
                                <asp:DropDownList ID="cmb_Organization" runat="server" CssClass="combobox" 
                                    Width="200px" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn_chart" OnClick="LinkButton2_Click"></asp:LinkButton>
                            </td>
                            <td class="loading_container">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="Up_OrganSelector">
                                    <ProgressTemplate>
                                        <div class="loading"></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:UpdatePanel ID="Up_Chart" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:Panel ID="pnl_Chart" runat="server" Visible="false">
                <table border="0" cellpadding="0" cellspacing="0" class="center">
                    <tr>
                        <td>
                            <asp:Chart ID="chart_Report" runat="server" Width="600px" Height="370px" BackColor="#f8f8f8">
                                <Series>
                                    <asp:Series Name="chart_Report_Series" YValueType="Int32">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chart_Report_Area" BackColor="#f6f6f6">
                                        <Area3DStyle Enable3D="true" Inclination="20" LightStyle="Realistic" WallWidth="15" Perspective="0" PointGapDepth="0" PointDepth="40"/>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

</div>