using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// Summary description for PollsRepository
/// </summary>
public class PollsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////////////////////////////
    public Poll Get(int Id)
    {
        try
        {
            return db.Polls.Single(poll => poll.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable<Poll> GetAll()
    {
        return db.Polls.OrderByDescending(poll => poll.DateOfCreate);
    }

    public Poll GetActivePoll()
    {
        var activePolls = db.Polls.Where(poll => poll.DateOfCreate.AddDays(poll.DaysOfActivity) >= MyHelper.Now).OrderByDescending(poll => poll.DateOfCreate);
        if (activePolls.Count() > 0)
            return activePolls.First();
        else
            return null;
    }

    public int GetAnswersCount(int pollId, int option)
    {
        return db.PollAnswers.Where(ans => ans.PollID == pollId && ans.SelectedOption == option).Count();
    }

    public void Delete(int pollId)
    {
        db.Polls.DeleteAllOnSubmit(db.Polls.Where(poll => poll.ID == pollId));
    }

    public void Add(Poll poll)
    {
        db.Polls.InsertOnSubmit(poll);
    }

    public void DeleteOptions(List<PollOption> options)
    {
        db.PollOptions.DeleteAllOnSubmit(options);
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}