using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_NotRoutedSuggestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Permissions.SuggestionsViewPermission)
                {
                    SuggestionsRepository sr = new SuggestionsRepository();
                    List<Suggestion> notRoutedSuggestions = sr.GetNotRoutedSuggestions().ToList();
                    uc_NotRoutedSuggestions.Suggestions = notRoutedSuggestions;
                }
                else
                {
                    uc_NotRoutedSuggestions.Visible = false;
                }
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}