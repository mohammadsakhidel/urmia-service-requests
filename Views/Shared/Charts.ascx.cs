using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using Models;

public partial class Views_Shared_Charts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MembersRepository mr = new MembersRepository();
            var organs = mr.GetAllOrganizations();
            cmb_Organization.Items.Clear();
            cmb_Organization.Items.Add(new ListItem("", "0"));
            foreach (Organization organ in organs)
            {
                cmb_Organization.Items.Add(new ListItem(organ.Name, organ.ID.ToString()));
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(3000);
            if (cmb_ChartType.SelectedValue == "1")
            {
                ShowSuggestionsChart();
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    private DataPoint GetDataPoint()
    {
        DataPoint point = new DataPoint();
        point.Color = MyHelper.GetRandomColor();
        point.Font = new System.Drawing.Font("Tahoma", 14);
        point.IsValueShownAsLabel = true;
        point.LabelForeColor = System.Drawing.Color.Gray;
        return point;
    }

    private void ShowOrganizationChart(int organId)
    {
        OrganizationsStatistics statistics = Statistics.OrganizationStatistics(organId);
        ////////////// all routings point:
        DataPoint pnt_all_routings = GetDataPoint();
        pnt_all_routings.AxisLabel = "کل ارجاعات";
        pnt_all_routings.YValues = new double[] { statistics.TotalRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_all_routings);
        ////////////// pending routings point:
        DataPoint pnt_pending_routings = GetDataPoint();
        pnt_pending_routings.AxisLabel = "منتظر پاسخ";
        pnt_pending_routings.YValues = new double[] { statistics.PendingRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_pending_routings);
        ////////////// verified routings point:
        DataPoint pnt_verified_routings = GetDataPoint();
        pnt_verified_routings.AxisLabel = "رسیدگی شده";
        pnt_verified_routings.YValues = new double[] { statistics.VerifyedRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_verified_routings);
        ////////////// rejected routings point:
        DataPoint pnt_rejected_routings = GetDataPoint();
        pnt_rejected_routings.AxisLabel = "رد شده";
        pnt_rejected_routings.YValues = new double[] { statistics.RejectedRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_rejected_routings);
        //////////////
        pnl_Chart.Visible = true;
        Up_Chart.Update();
    }

    private void ShowSuggestionsChart()
    {
        SuggestionsStatistics statistics = Statistics.SuggestionsStatistics;
        ////////////// all suggestions point:
        DataPoint pnt_all_suggestions = GetDataPoint();
        pnt_all_suggestions.AxisLabel = "کل پیشنهادات";
        pnt_all_suggestions.YValues = new double[] { statistics.TotalSuggestionsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_all_suggestions);
        ////////////// all routings point:
        DataPoint pnt_all_routings = GetDataPoint();
        pnt_all_routings.AxisLabel = "کل ارجاعات";
        pnt_all_routings.YValues = new double[] { statistics.TotalRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_all_routings);
        ////////////// pending routings point:
        DataPoint pnt_pending_routings = GetDataPoint();
        pnt_pending_routings.AxisLabel = "منتظر پاسخ";
        pnt_pending_routings.YValues = new double[] { statistics.PendingRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_pending_routings);
        ////////////// verified routings point:
        DataPoint pnt_verified_routings = GetDataPoint();
        pnt_verified_routings.AxisLabel = "رسیدگی شده";
        pnt_verified_routings.YValues = new double[] { statistics.VerifyedRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_verified_routings);
        ////////////// rejected routings point:
        DataPoint pnt_rejected_routings = GetDataPoint();
        pnt_rejected_routings.AxisLabel = "رد شده";
        pnt_rejected_routings.YValues = new double[] { statistics.RejectedRoutingsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_rejected_routings);
        ////////////// not routed suggestions point:
        DataPoint pnt_not_routed = GetDataPoint();
        pnt_not_routed.AxisLabel = "هدایت نشده";
        pnt_not_routed.YValues = new double[] { statistics.NotRoutedSuggestionsCount };
        chart_Report.Series["chart_Report_Series"].Points.Add(pnt_not_routed);
        //////////////
        pnl_Chart.Visible = true;
        Up_Chart.Update();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(2500);
            if (cmb_Organization.SelectedIndex > 0)
            {
                ShowOrganizationChart(Convert.ToInt32(cmb_Organization.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}