using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Shared_ReportForMayer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int Month
    {
        get
        {
            return Convert.ToInt32(ViewState["Month"]);
        }
        set
        {
            ViewState["Month"] = value;
            cmb_Month.SelectedIndex = MyHelper.FindIndex(cmb_Month.Items, value.ToString());
        }
    }

    public int Year
    {
        get
        {
            return Convert.ToInt32(ViewState["Year"]);
        }
        set
        {
            ViewState["Year"] = value;
            cmb_Year.SelectedIndex = MyHelper.FindIndex(cmb_Year.Items, value.ToString());
        }
    }

    public void ShowReport()
    {
        ReportForMayor rpt = new ReportForMayor(Month, Year);
        lbl_TotalSuggestionsCount.Text = rpt.TotalSuggestionsCount.ToString();
        lbl_PendingsCount.Text = rpt.PendingsCount.ToString();
        lbl_VerifiedsCount.Text = rpt.VerifiedsCount.ToString();
        lbl_RejectedsCount.Text = rpt.RejectedsCount.ToString();
        lbl_MaxRoutings.Text = rpt.MaxRoutedOrgan != null ? rpt.MaxRoutedOrgan.Name : "";
        lbl_MaxVerified.Text = rpt.MaxVerifiedOrgan != null ? rpt.MaxVerifiedOrgan.Name : "";
        lbl_MaxPendings.Text = rpt.MaxPendingsOrgan != null ? rpt.MaxPendingsOrgan.Name : "";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Month = Convert.ToInt32(cmb_Month.SelectedValue);
            Year = Convert.ToInt32(cmb_Year.SelectedValue);
            ShowReport();
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}