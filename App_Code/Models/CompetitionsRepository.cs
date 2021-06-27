using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// Summary description for CompetitionsRepository
/// </summary>
public class CompetitionsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////////////////////////////
    public IEnumerable<Competition> GetAll()
    {
        return db.Competitions.OrderByDescending(com => com.DateOfCreate);
    }

    public Competition Get(int Id)
    {
        try
        {
            return db.Competitions.Single(com => com.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public Competition GetActiveCompetition()
    {
        var activeComps = db.Competitions.Where(comp => comp.DateOfCreate.AddDays(comp.DaysOfActivity) >= MyHelper.Now).OrderByDescending(comp => comp.DateOfCreate);
        if (activeComps.Count() > 0)
            return activeComps.First();
        else
            return null;
    }

    public int GetAnswersCount(int competitionId, int selectedOption)
    {
        return db.CompetitionAnswers.Where(ans => ans.CompetitionID == competitionId && ans.Answer == selectedOption.ToString()).Count();
    }

    public void Add(Competition competition)
    {
        db.Competitions.InsertOnSubmit(competition);
    }

    public void Delete(int Id)
    {
        db.Competitions.DeleteAllOnSubmit(db.Competitions.Where(com => com.ID == Id));
    }

    public void DeleteOptions(IEnumerable<CompetitionOption> options)
    {
        db.CompetitionOptions.DeleteAllOnSubmit(options);
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}