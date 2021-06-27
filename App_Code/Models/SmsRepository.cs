using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Models;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SmsRepository
/// </summary>
public class SmsRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////////////////////////////
    public RecievedMessage GetRecievedMessage(int id)
    {
        try
        {
            return db.RecievedMessages.Single(sms => sms.ID == id);
        }
        catch
        {
            return null;
        }
    }

    public SentMessage GetSentMessage(int Id)
    {
        try
        {
            return db.SentMessages.Single(sms => sms.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public void Add(RecievedMessage sms)
    {
        db.RecievedMessages.InsertOnSubmit(sms);
    }

    public IEnumerable<RecievingError> GetErrors()
    {
        return db.RecievingErrors.OrderByDescending(error => error.DateOf);
    }

    public void AddError(RecievingError error)
    {
        db.RecievingErrors.InsertOnSubmit(error);
    }

    public void AddSentMessage(SentMessage sms)
    {
        db.SentMessages.InsertOnSubmit(sms);
    }

    public void AddInteractiveSentMessage(InteractiveSentMessage sms)
    {
        db.InteractiveSentMessages.InsertOnSubmit(sms);
    }

    public IEnumerable<SentMessage> GetAllSentMessages()
    {
        return db.SentMessages.OrderByDescending(sms => sms.DateOfSend);
    }

    public IEnumerable<RecievedMessage> FindRecievedMessages(List<Hashtable> conditions)
    {
        IEnumerable<RecievedMessage> temp = db.RecievedMessages.AsEnumerable();
        List<RecievedMessage> messages = new List<RecievedMessage>();
        foreach (Hashtable condition in conditions)
        {
            if (Convert.ToInt32(condition["field"]) == 1)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    messages = temp.Where(msg => msg.Text == condition["value"].ToString()).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    messages = temp.Where(msg => msg.Text.Contains(condition["value"].ToString())).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 2)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    messages = temp.Where(msg => msg.DateOfRecieve.Date == Controllers.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate.Date).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    messages = temp.Where(msg => msg.DateOfRecieve.Date < Controllers.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate.Date).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    messages = temp.Where(msg => msg.DateOfRecieve.Date > Controllers.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate.Date).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 3)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    messages = temp.Where(msg => msg.ProcessResult == Convert.ToInt32(condition["value"])).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 4)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    messages = temp.Where(msg => msg.Citizen.MobNumber == condition["value"].ToString()).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    messages = temp.Where(msg => msg.Citizen.MobNumber.Contains(condition["value"].ToString())).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 5)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    messages = temp.Where(msg => msg.Citizen.Zone != null && msg.Citizen.Zone == condition["value"].ToString()).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    messages = temp.Where(msg => msg.Citizen.Zone != null && msg.Citizen.Zone.Contains(condition["value"].ToString())).ToList();
                }
            }
            else if (Convert.ToInt32(condition["field"]) == 6)
            {
                if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    messages = temp.Where(msg => msg.Citizen.Address != null && msg.Citizen.Address == condition["value"].ToString()).ToList();
                }
                else if (Convert.ToInt32(condition["condition"]) == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    messages = temp.Where(msg => msg.Citizen.Address != null && msg.Citizen.Address.Contains(condition["value"].ToString())).ToList();
                }
            }
            temp = messages;
        }
        return messages;
    }

    public RecievedMessage Insert(RecievedMessage sms)
    {
        SqlConnection conn = new SqlConnection(MyHelper.ConnectionString);
        try
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO RecievedMessages (CitizenID, Text, DateOfRecieve, [Status], ProcessResult) VALUES (" + sms.CitizenID + ", N'" + sms.Text + "', @DateOfRecieve, " + sms.Status + ", " + sms.ProcessResult + "); SELECT SCOPE_IDENTITY();", conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@DateOfRecieve";
            param.Value = sms.DateOfRecieve;
            comm.Parameters.Add(param);
            int smsId = Convert.ToInt32(comm.ExecuteScalar());
            conn.Close();
            return GetRecievedMessage(smsId);
        }
        catch
        {
            conn.Close();
            return null;
        }
    }

    public void Save()
    {
        db.SubmitChanges();
    }
}