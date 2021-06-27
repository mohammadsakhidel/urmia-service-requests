using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ActiveCompetition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Permissions.CompetitionsViewPermission)
                {
                    CompetitionsRepository cr = new CompetitionsRepository();
                    Competition activeComp = cr.GetActiveCompetition();
                    uc_ActiveCompetition.Competition = activeComp;
                }
                else
                {
                    uc_ActiveCompetition.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}