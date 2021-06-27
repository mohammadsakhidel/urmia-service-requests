using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// Summary description for OrganPanelInfo
/// </summary>
public class OrganPanelInfo
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    ////////////////////////////////////////////////////////////////////////////////
	public OrganPanelInfo()
	{
        Organization organ = Organization.CurrentUser;
        if (organ != null)
        {
            PendingSuggestionsCount = organ.PendingSuggestions.Where(sug => sug.Visible).Count();
            OutOfDateSuggestionsCount = organ.OutOfDateSuggestions.Count();
            VerifiedSuggestionsCount = organ.VerifiedSuggestions.Count();
            RejectedSuggestionsCount = organ.RejectedSuggestions.Count();
            ShowNotRoutedSuggestions = organ.ViewUnroutedSuggestions;
            NotRoutedSuggestionsCount = db.Suggestions.Where(sug => sug.Visible && sug.Status == (int)MyEnums.SuggestionStatus.NotRouted).Count();
        }
	}
    //******************** Properties:
    public int PendingSuggestionsCount { get; set; }
    public int OutOfDateSuggestionsCount { get; set; }
    public int VerifiedSuggestionsCount { get; set; }
    public int RejectedSuggestionsCount { get; set; }
    public bool ShowNotRoutedSuggestions { get; set; }
    public int NotRoutedSuggestionsCount { get; set; }

}