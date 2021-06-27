using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Supervisors_ActiveCompetition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                CompetitionsRepository cr = new CompetitionsRepository();
                Competition activeComp = cr.GetActiveCompetition();
                uc_ActiveCompetition.Competition = activeComp;
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}