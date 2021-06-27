using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_ToolWindows_DetailsOfCitizen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MembersRepository mr = new MembersRepository();
            Citizen citizen = mr.GetCitizen(Convert.ToInt32(Request.QueryString["Id"]));
            if (citizen != null)
                uc_CitizenDetails.Citizen = citizen;
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}