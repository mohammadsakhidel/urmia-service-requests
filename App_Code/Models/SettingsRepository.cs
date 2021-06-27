using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

public class SettingsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////////////////////////////
    public ResponseSetting GetResponseSetting()
    {
        try
        {
            return db.ResponseSettings.First();
        }
        catch
        {
            return null;
        }
    }

    public InformSetting GetInformSetting()
    {
        try
        {
            return db.InformSettings.First();
        }
        catch
        {
            return null;
        }
    }

    public void DeleteResponseSettings()
    {
        db.ResponseSettings.DeleteAllOnSubmit(db.ResponseSettings);
    }

    public void DeleteInformSettings()
    {
        db.InformSettings.DeleteAllOnSubmit(db.InformSettings);
    }

    public void Add(ResponseSetting setting)
    {
        db.ResponseSettings.InsertOnSubmit(setting);
    }

    public void Add(InformSetting setting)
    {
        db.InformSettings.InsertOnSubmit(setting);
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}