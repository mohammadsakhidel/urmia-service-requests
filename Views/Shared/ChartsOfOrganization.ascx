<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChartsOfOrganization.ascx.cs" Inherits="ChartsOfOrganization" %>


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
                </asp:DropDownList>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_ShowChart" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_chart" OnClick="LinkButton1_Click"></asp:LinkButton>
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