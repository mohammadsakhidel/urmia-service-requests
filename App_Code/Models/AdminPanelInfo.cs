using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// Summary description for AdminPanelInfo
/// </summary>
public class AdminPanelInfo
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    ////////////////////////////////////////////////////////////////////////////////
    //******** Users:
    public int OrganizationsCount { get { return db.Organizations.Count(); } }
    public int OperatorsCount { get { return db.Operators.Count(); } }
    public int SupervisorsCount { get { return db.Supervisors.Count(); } }
    public int CitizensCount { get { return db.Citizens.Count(); } }
    //******** suggestions:
    public int RoutedSuggestionsCount { get { return db.SuggestionRoutings.Where(sug => sug.Visible && sug.Status == (int)MyEnums.SuggestionRoutingStatus.Pending).Count(); } }
    public int NotRoutedSuggestionsCount { get { return db.Suggestions.Where(sug => sug.Visible && sug.Status == (int)MyEnums.SuggestionStatus.NotRouted).Count(); } }
    public int TrashSuggestionsCount { get { return db.Suggestions.Where(sug => !sug.Visible).Count() + db.SuggestionRoutings.Where(sug => !sug.Visible).Count(); } }

    //******** polls:
    public int PollsCount { get { return db.Polls.Count(); } }
    public int ActivePollAnswersCount 
    { 
        get 
        {
            PollsRepository pr = new PollsRepository();
            Poll active = pr.GetActivePoll();
            if (active != null)
                return active.PollAnswers.Count();
            else 
                return -1;
        }
    }
    //******** competitions:
    public int CompetitionsCount { get { return db.Competitions.Count(); } }
    public int ActiveCompetitionAnswersCount
    {
        get
        {
            CompetitionsRepository cr = new CompetitionsRepository();
            Competition active = cr.GetActiveCompetition();
            if (active != null)
                return active.CompetitionAnswers.Count();
            else
                return -1;
        }
    }
}