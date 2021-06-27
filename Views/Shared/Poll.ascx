<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Poll.ascx.cs" Inherits="Views_Shared_Poll" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Panel ID="pnl_ActivePoll" runat="server">

    <div style="margin-top : 20px;">
        <asp:Label ID="lbl_poll_subject" runat="server" Text="" CssClass="subject"></asp:Label>
    </div>

    <asp:Chart ID="ch_PollResult" runat="server">
        <Series>
            <asp:Series Name="ch_PollResult_Series" YValueType="Int32">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BackColor="#f6f6f6">
                <Area3DStyle Enable3D="true" Inclination="20" LightStyle="Realistic" WallWidth="15" Perspective="0" PointGapDepth="0" PointDepth="40"/>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

    <table border="0" cellpadding="3" cellspacing="0" class="center resume">
        <tr>
            <td align="left">
                <span class="resume_label">
                    تعداد کل آراء :
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
