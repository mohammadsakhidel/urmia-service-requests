using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_ToolWindows_DetailsOfCompetition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                CompetitionsRepository cr = new CompetitionsRepository();
                Competition comp = cr.Get(Id);
                uc_Competition.Competition = comp;
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}