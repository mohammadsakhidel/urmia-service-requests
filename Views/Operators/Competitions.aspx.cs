using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_Competitions : System.Web.UI.Page
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
                    uc_Competitions.Competitions = cr.GetAll().ToList();
                }
                else
                {
                    uc_Competitions.Visible = false;
                }
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}