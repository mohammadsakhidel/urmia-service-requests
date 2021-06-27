using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Organizations_OutOfDateSuggestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MembersRepository mr = new MembersRepository();
            Organization organ = mr.GetOrganization(MyHelper.CurrentUserName);
            if (organ != null)
            {
                uc_OutOfDateSuggestions.OrganizationID = organ.ID;
                uc_OutOfDateSuggestions.LoadSuggestions();
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}