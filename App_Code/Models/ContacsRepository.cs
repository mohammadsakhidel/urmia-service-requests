using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Models;

public class ContacsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    ////////////////////////////////////////////////////////////////////////////////
    public List<Contact> FindContacts(List<Hashtable> conditions)
    {
        List<Contact> founds = (conditions.Count() > 0 ? GetContactBook(Convert.ToInt32(conditions[0]["book"])).Contacts.ToList() : new List<Contact>());
        foreach (Hashtable condition in conditions)
        {
            string searchedValue = condition["value"].ToString();
            int searchedField = Convert.ToInt32(condition["field"]);
            int searchedCondition = Convert.ToInt32(condition["condition"]);
            if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
            {
                founds = founds.Where(contact => Contact.GetValue(contact.ID, searchedField) == searchedValue).ToList();
            }
            else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Like)
            {
                founds = founds.Where(contact => Contact.GetValue(contact.ID, searchedField).Contains(searchedValue)).ToList();
            }
        }
        return founds;
    }

    public ContactBook GetContactBook(int Id)
    {
        try
        {
            return db.ContactBooks.Single(book => book.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable<ContactBook> GetContactBooks()
    {
        return db.ContactBooks.OrderByDescending(book => book.DateOfCreate);
    }

    public Contact GetContact(string mobNumber)
    {
        try
        {
            return db.Contacts.Single(c => c.MobNumber == mobNumber);
        }
        catch
        {
            return null;
        }
    }

    public Contact GetContact(int Id)
    {
        try
        {
            return db.Contacts.Single(c => c.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public bool ContactExists(string mob)
    {
        return db.Contacts.Where(c => c.MobNumber == mob).Count() > 0;
    }

    public void AddBook(ContactBook book)
    {
        db.ContactBooks.InsertOnSubmit(book);
    }

    public void DeleteField(int Id)
    {
        db.FieldValues.DeleteAllOnSubmit(db.FieldValues.Where(fv => fv.FieldID == Id));
        db.Fields.DeleteAllOnSubmit(db.Fields.Where(fv => fv.ID == Id));
    }

    public void DeleteBook(int Id)
    {
        db.ContactBooks.DeleteAllOnSubmit(db.ContactBooks.Where(book => book.ID == Id));
    }

    public void DeleteContact(int Id)
    {
        db.Contacts.DeleteAllOnSubmit(db.Contacts.Where(c => c.ID == Id));
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}