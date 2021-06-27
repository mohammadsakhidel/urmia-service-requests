using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

public class PatternsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////////////////////////////
    public IEnumerable<Pattern> GetAllPatterns()
    {
        return db.Patterns.OrderByDescending(pat => pat.DateOfCreate);
    }

    public Pattern Get(int Id)
    {
        try
        {
            return db.Patterns.Single(pat => pat.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public void Add(Pattern pattern)
    {
        db.Patterns.InsertOnSubmit(pattern);
    }

    public void DeletePattern(int Id)
    {
        db.Patterns.DeleteAllOnSubmit(db.Patterns.Where(pat => pat.ID == Id));
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}