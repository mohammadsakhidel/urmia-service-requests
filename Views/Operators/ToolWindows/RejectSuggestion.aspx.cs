using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ToolWindows_RejectSuggestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                SuggestionsRepository sr = new SuggestionsRepository();
                SuggestionRouting routing = sr.GetRouting(Id);
                uc_RejectSuggestion.SuggestionRouting = routing;
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}