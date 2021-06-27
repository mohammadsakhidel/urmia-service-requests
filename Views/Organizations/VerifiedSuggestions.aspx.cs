using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Organizations_VerifiedSuggestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Organization organ = Organization.CurrentUser;
            uc_SuggestionRoutings.OrganizationID = organ.ID;
            uc_SuggestionRoutings.Status = (int)MyEnums.SuggestionRoutingStatus.Verified;
            uc_SuggestionRoutings.LoadSuggestions();
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}