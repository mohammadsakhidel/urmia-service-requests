using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;

public partial class Views_Mayor_ReportForMayer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                ShamsiDateTime shamsi = ShamsiDateTime.MiladyToShamsi(MyHelper.Now);
                uc_ReportForMayer.Year = shamsi.Year;
                uc_ReportForMayer.Month = shamsi.Month;
                uc_ReportForMayer.ShowReport();
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}