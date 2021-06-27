using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

public class ServiceRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    ///////////////////////////////////////////////////////////////////////////////// MONAGHESAT
    public Monagheseh GetMonagheseh(int Id)
    {
        try
        {
            return db.Monaghesehs.Single(mon => mon.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable<Monagheseh> GetMonaghesat()
    {
        return db.Monaghesehs.OrderBy(m => m.DateOfStart).AsEnumerable();
    }

    public IEnumerable<Monagheseh> GetActiveMonaghesat()
    {
        return db.Monaghesehs.Where(m => m.DateOfEnd.Date > MyHelper.Now.Date).OrderBy(m => m.DateOfStart).Take(Digits.MaxMonaghesatPerSms).AsEnumerable();
    }

    public void AddMonagheseh(Monagheseh monagheseh)
    {
        db.Monaghesehs.InsertOnSubmit(monagheseh);
    }

    public void DeleteMonagheseh(int Id)
    {
        db.Monaghesehs.DeleteAllOnSubmit(db.Monaghesehs.Where(mon => mon.ID == Id));
    }

    ///////////////////////////////////////////////////////////////////////////////// MOZAIEDAT
    public Mozaiedeh GetMozaiedeh(int Id)
    {
        try
        {
            return db.Mozaiedehs.Single(moz => moz.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable<Mozaiedeh> GetMozaiedat()
    {
        return db.Mozaiedehs.OrderBy(m => m.DateOfStart).AsEnumerable();
    }

    public IEnumerable<Mozaiedeh> GetActiveMozaiedat()
    {
        return db.Mozaiedehs.Where(m => m.DateOfEnd.Date > MyHelper.Now.Date).OrderBy(m => m.DateOfStart).Take(Digits.MaxMozaiedatPerSms).AsEnumerable();
    }

    public void AddMozaiedeh(Mozaiedeh mozaiedeh)
    {
        db.Mozaiedehs.InsertOnSubmit(mozaiedeh);
    }

    public void DeleteMozaiedeh(int Id)
    {
        db.Mozaiedehs.DeleteAllOnSubmit(db.Mozaiedehs.Where(moz => moz.ID == Id));
    }

    /////////////////////////////////////////////////////////////////////////////////

    public void Save()
    {
        db.SubmitChanges();
    }
}