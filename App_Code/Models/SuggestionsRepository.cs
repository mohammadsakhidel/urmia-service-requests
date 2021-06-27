using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Models;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SuggestionsRepository
/// </summary>
public class SuggestionsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////////////////////////////
    public Suggestion Get(int Id)
    {
        try
        {
            return db.Suggestions.Single(sug => sug.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public Suggestion Get(string persuitCode)
    {
        try
        {
            return db.Suggestions.Single(sug => sug.PersuitCode == persuitCode);
        }
        catch
        {
            return null;
        }
    }

    public SuggestionRouting GetRouting(int Id)
    {
        try
        {
            return db.SuggestionRoutings.Single(sug => sug.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public SuggestionsStatistics GetSuggestionsStatistics()
    {
        SuggestionsStatistics statistics = new SuggestionsStatistics();
        statistics.TotalSuggestionsCount = db.Suggestions.Count();
        statistics.TotalRoutingsCount = db.SuggestionRoutings.Count();
        statistics.VerifyedRoutingsCount = db.SuggestionRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Verified).Count();
        statistics.RejectedRoutingsCount = db.SuggestionRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected).Count();
        statistics.PendingRoutingsCount = db.SuggestionRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Pending).Count();
        statistics.NotRoutedSuggestionsCount = db.Suggestions.Where(sug => sug.Status == (int)MyEnums.SuggestionStatus.NotRouted).Count();
        return statistics;
    }

    public IEnumerable<SuggestionRouting> GetOutOfDateSuggestions()
    {
        return db.SuggestionRoutings.Where(rout => rout.Visible && (rout.Status == (int)MyEnums.SuggestionRoutingStatus.Pending && rout.DateOfRoute.AddDays(Digits.OutOfDateDays).Date < MyHelper.Now.Date));
    }

    public IEnumerable<SuggestionRouting> GetOutOfDateSuggestions(int organId)
    {
        return db.SuggestionRoutings.Where(rout => rout.OrganizationID == organId && rout.Visible && (rout.Status == (int)MyEnums.SuggestionRoutingStatus.Pending && rout.DateOfRoute.AddDays(Digits.OutOfDateDays).Date < MyHelper.Now.Date));
    }

    public IEnumerable<Suggestion> GetNotRoutedSuggestions()
    {
        return db.Suggestions.Where(sug => sug.Visible && sug.Status == (int)MyEnums.SuggestionStatus.NotRouted).OrderByDescending(sug => sug.RecievedMessage.DateOfRecieve);
    }

    public void Add(Suggestion suggestion)
    {
        db.Suggestions.InsertOnSubmit(suggestion);
    }

    public Suggestion Insert(Suggestion suggestion)
    {
        SqlConnection conn = new SqlConnection(MyHelper.ConnectionString);
        try
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Suggestions (RecievedMessageID, [Status], PersuitCode, Visible) VALUES (" + suggestion.RecievedMessageID + ", " + suggestion.Status + ", '" + suggestion.PersuitCode + "', " + (suggestion.Visible ? 1 : 0) + "); SELECT SCOPE_IDENTITY();", conn);
            int sugID = Convert.ToInt32(comm.ExecuteScalar());
            conn.Close();
            return Get(sugID);
        }
        catch
        {
            conn.Close();
            return null;
        }
    }

    public List<Organization> GetRelatedOrganizations(Suggestion suggestion)
    {
        List<Organization> list = new List<Organization>();
        string smsText = suggestion.RecievedMessage.Text;
        int keyMinLength = 2;
        foreach (Organization organ in db.Organizations)
        {
            bool hasKeyword = false;
            //calculate points:
            foreach (OrganizationKeyword keyword in organ.OrganizationKeywords)
            {

                if ((keyword.Text.Length > keyMinLength && smsText.Contains(keyword.Text)) || (keyword.Text.Length <= keyMinLength && smsText.Contains(" " + keyword.Text + " ")))
                {
                    organ.Points = (organ.Points != null ? organ.Points + 1 : 0);
                    hasKeyword = true;
                }
            }
            //add:
            if (hasKeyword)
                list.Add(organ);
        }
        return list.OrderByDescending(org => org.Points).Take(3).ToList();
    }

    public string GetNewPersuitCode()
    {
        Random random = new Random(MyHelper.Now.Millisecond);
        string randomCode = MyHelper.GetRandomString(12, false);
        if (!db.Suggestions.Where(sug => sug.PersuitCode == randomCode).Any())
            return randomCode;
        else
        {
            System.Threading.Thread.Sleep(1);
            return GetNewPersuitCode();
        }
    }

    public IEnumerable<SuggestionRouting> GetSuggestionRoutings(int organ, int status)
    {
        var routings = (organ == 0 ? db.SuggestionRoutings.Where(rout => rout.Visible) : db.SuggestionRoutings.Where(rout => rout.OrganizationID == organ && rout.Visible));
        routings = (status == 0 ? routings : routings.Where(r => r.Status == status));
        return routings.OrderByDescending(r => r.DateOfRoute);
    }

    public void LogicalDeleteRouting(int Id)
    {
        SuggestionRouting sRouting = GetRouting(Id);
        if (sRouting != null)
            sRouting.Visible = false;
    }

    public void LogicalDeleteSuggestion(int Id)
    {
        Suggestion suggestion = Get(Id);
        if (suggestion != null)
            suggestion.Visible = false;
    }

    public IEnumerable<SuggestionRouting> GetDeletedRoutings()
    {
        return db.SuggestionRoutings.Where(rout => !rout.Visible);
    }

    public IEnumerable<Suggestion> GetDeletedSuggestions()
    {
        return db.Suggestions.Where(sug => !sug.Visible);
    }

    public void DeleteRouting(int Id)
    {
        SuggestionRouting routing = GetRouting(Id);
        if (routing != null)
        {
            if (routing.Suggestion.SuggestionRoutings.Count() > 1)
                db.SuggestionRoutings.DeleteAllOnSubmit(db.SuggestionRoutings.Where(rout => rout.ID == Id));
            else
                DeleteSuggestion(routing.SuggestionID);
        }
    }

    public void DeleteSuggestion(int Id)
    {
        db.Suggestions.DeleteAllOnSubmit(db.Suggestions.Where(sug => sug.ID == Id));
    }

    public void RestoreSuggestion(int Id)
    {
        Suggestion sug = Get(Id);
        if (sug != null)
            sug.Visible = true;
    }

    public void RestoreSuggestionRouting(int Id)
    {
        SuggestionRouting sug = GetRouting(Id);
        if (sug != null)
            sug.Visible = true;
    }

    public List<Suggestion> FindSuggestions(List<Hashtable> conditions, Organization organ)
    {
        List<Suggestion> founds = new List<Suggestion>();
        IEnumerable<Suggestion> temp = (organ == null ? db.Suggestions.AsEnumerable() : organ.SuggestionRoutings.Select(rout => rout.Suggestion).Distinct().AsEnumerable());
        int i = 0;
        foreach (Hashtable condition in conditions)
        {
            string searchedValue = condition["value"].ToString();
            if (Convert.ToInt32(condition["field"]) == 1)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(sug => sug.Visible && sug.RecievedMessage.Text == searchedValue).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    founds = temp.Where(sug => sug.Visible && sug.RecievedMessage.Text.Contains(searchedValue)).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 2)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(sug => sug.Visible && sug.SuggestionRoutings.Select(routing => routing.OrganizationID).Contains(Convert.ToInt32(searchedValue))).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 3)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    if (organ == null)
                    {
                        if (Convert.ToInt32(searchedValue) > 0)
                            founds = temp.Where(sug => sug.Visible && sug.SuggestionRoutings.Select(routing => routing.Status).Contains(Convert.ToInt32(searchedValue))).ToList();
                        else if (Convert.ToInt32(searchedValue) == 0)
                            founds = temp.Where(sug => sug.Visible && sug.Status == (int)MyEnums.SuggestionStatus.NotRouted).ToList();
                    }
                    else
                    {
                        if (Convert.ToInt32(searchedValue) > 0)
                            founds = temp.Where(sug => sug.Visible && sug.SuggestionRoutings.Where(routing => routing.OrganizationID == organ.ID).Select(routing => routing.Status).Contains(Convert.ToInt32(searchedValue))).ToList();
                        else if (Convert.ToInt32(searchedValue) == 0)
                            founds = temp.Where(sug => sug.Visible && sug.Status == (int)MyEnums.SuggestionStatus.NotRouted).ToList();
                    }
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 4)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(sug => sug.Visible && sug.RecievedMessage.DateOfRecieve.Date == Controllers.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate.Date).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    founds = temp.Where(sug => sug.Visible && sug.RecievedMessage.DateOfRecieve.Date < Controllers.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate.Date).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    founds = temp.Where(sug => sug.Visible && sug.RecievedMessage.DateOfRecieve.Date > Controllers.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate.Date).ToList();
                }
            }
            temp = founds;
            i++;
        }
        return founds;
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}