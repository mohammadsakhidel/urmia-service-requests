using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_NotRoutedSuggestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                SuggestionsRepository sr = new SuggestionsRepository();
                List<Suggestion> notRoutedSuggestions = sr.GetNotRoutedSuggestions().ToList();
                uc_NotRoutedSuggestions.Suggestions = notRoutedSuggestions;
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}