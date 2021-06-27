using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using Models;

public partial class ChartsOfOrganization : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (cmb_ChartType.SelectedValue == "1")
            {
                ShowOrganizationChart(Organization.CurrentUser.ID);
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
}