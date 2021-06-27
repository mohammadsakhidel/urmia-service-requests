using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Models;

/// <summary>
/// Summary description for MembersRepository
/// </summary>
public class MembersRepository
{
    MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
    /////////////////////////////////////////////////////////// CITIZENS:
    public Citizen FindOrCreate(string mobNumber, string name = "")
    {
        try
        {
            return db.Citizens.Single(c => c.MobNumber == mobNumber);
        }
        catch
        {
            Citizen citizen = new Citizen();
            citizen.MobNumber = mobNumber;
            if (!String.IsNullOrEmpty(name))
                citizen.Name = name;
            citizen.DateOfAdd = MyHelper.Now;
            db.Citizens.InsertOnSubmit(citizen);
            Save();
            return citizen;
        }
    }

    public Citizen GetCitizen(int Id)
    {
        try
        {
            return db.Citizens.Single(c => c.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public List<string> GetAllCitizenNumbers()
    {
        return db.Citizens.Select(c => c.MobNumber).ToList();
    }

    public List<Citizen> FindCitizens(List<Hashtable> conditions)
    {
        List<Citizen> founds = new List<Citizen>();
        IEnumerable<Citizen> temp = db.Citizens.AsEnumerable();
        foreach (Hashtable condition in conditions)
        {
            string searchedValue = condition["value"].ToString();
            int searchedField = Convert.ToInt32(condition["field"]);
            int searchedCondition = Convert.ToInt32(condition["condition"]);
            if (searchedField == 1)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.MobNumber == searchedValue).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    founds = temp.Where(citizen => citizen.MobNumber.Contains(searchedValue)).ToList();
                }
            }
            else if (searchedField == 2)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.Name == searchedValue).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    founds = temp.Where(citizen => citizen.Name.Contains(searchedValue)).ToList();
                }
            }
            else if (searchedField == 3)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.Gender == Convert.ToInt32(searchedValue)).ToList();
                }
            }
            else if (searchedField == 4)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.BornYear == Convert.ToInt32(searchedValue)).ToList();
                }
            }
            else if (searchedField == 5)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.Job == searchedValue).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    founds = temp.Where(citizen => citizen.Job.Contains(searchedValue)).ToList();
                }
            }
            else if (searchedField == 6)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.Zone == searchedValue).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    founds = temp.Where(citizen => citizen.Zone.Contains(searchedValue)).ToList();
                }
            }
            else if (searchedField == 7)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.Address == searchedValue).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Like)
                {
                    founds = temp.Where(citizen => citizen.Address.Contains(searchedValue)).ToList();
                }
            }
            else if (searchedField == 8)
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.DateOfAdd.Date == Controllers.ShamsiDateTime.FromText(searchedValue).MiladyDate.Date).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    founds = temp.Where(citizen => citizen.DateOfAdd.Date < Controllers.ShamsiDateTime.FromText(searchedValue).MiladyDate.Date).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    founds = temp.Where(citizen => citizen.DateOfAdd.Date > Controllers.ShamsiDateTime.FromText(searchedValue).MiladyDate.Date).ToList();
                }
            }
            else if (searchedField == 9 && MyHelper.IsInteger(searchedValue))
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Count() == Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Count() < Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Count() > Convert.ToInt32(searchedValue)).ToList();
                }
            }
            else if (searchedField == 10 && MyHelper.IsInteger(searchedValue))
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectSuggestion).Count() == Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectSuggestion).Count() < Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectSuggestion).Count() > Convert.ToInt32(searchedValue)).ToList();
                }
            }
            else if (searchedField == 11 && MyHelper.IsInteger(searchedValue))
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectPollAnswer).Count() == Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectPollAnswer).Count() < Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectPollAnswer).Count() > Convert.ToInt32(searchedValue)).ToList();
                }
            }
            else if (searchedField == 12 && MyHelper.IsInteger(searchedValue))
            {
                if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Equal)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer).Count() == Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Fewer)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer).Count() < Convert.ToInt32(searchedValue)).ToList();
                }
                else if (searchedCondition == (int)MyEnums.AdvancedSearchCondition.Greater)
                {
                    founds = temp.Where(citizen => citizen.RecievedMessages.Where(sms => sms.ProcessResult == (int)MyEnums.RecievedMessageProcessResult.CorrectCompetitionAnswer).Count() > Convert.ToInt32(searchedValue)).ToList();
                }
            }
            temp = founds;
        }
        return founds;
    }
    /////////////////////////////////////////////////////////// ORGANIZATIONS:
    public Organization GetOrganization(int Id)
    {
        try
        {
            return db.Organizations.Single(o => o.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public Organization GetOrganization(string userName)
    {
        try
        {
            return db.Organizations.Single(o => o.UserName == userName);
        }
        catch
        {
            return null;
        }
    }

    public void AddOrganization(Organization organ)
    {
        db.Organizations.InsertOnSubmit(organ);
    }

    public IEnumerable<Organization> GetAllOrganizations()
    {
        return db.Organizations;
    }

    public void DeleteOrganization(Organization organ)
    {
        db.Organizations.DeleteOnSubmit(organ);
    }

    public void DeleteKeywords(List<OrganizationKeyword> keys)
    {
        foreach (OrganizationKeyword key in keys)
            db.OrganizationKeywords.DeleteAllOnSubmit(db.OrganizationKeywords.Where(k => k.ID == key.ID));
    }
    /////////////////////////////////////////////////////////// OPERATORS:
    public void Add(OperatorAccessRule rule)
    {
        db.OperatorAccessRules.InsertOnSubmit(rule);
    }

    public IEnumerable<Operator> GetAllOperators()
    {
        return db.Operators;
    }

    public Operator GetOperator(int Id)
    {
        try
        {
            return db.Operators.Single(o => o.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public Operator GetOperator(string userName)
    {
        try
        {
            return db.Operators.Single(o => o.UserName == userName);
        }
        catch
        {
            return null;
        }
    }

    public void AddOperator(Operator op)
    {
        db.Operators.InsertOnSubmit(op);
    }

    public void DeleteOperator(Operator op)
    {
        db.Operators.DeleteOnSubmit(op);
    }

    public OperatorAccessRule GetOperatorAccessRule()
    {
        try
        {
            return db.OperatorAccessRules.First();
        }
        catch
        {
            return null;
        }
    }

    public void DeleteOperatorAccessRules()
    {
        db.OperatorAccessRules.DeleteAllOnSubmit(db.OperatorAccessRules);
    }
    /////////////////////////////////////////////////////////// SUPERVISORS:
    public IEnumerable<Supervisor> GetAllSupervisors()
    {
        return db.Supervisors;
    }

    public Supervisor GetSupervisor(int Id)
    {
        try
        {
            return db.Supervisors.Single(sup => sup.ID == Id);
        }
        catch
        {
            return null;
        }
    }

    public OrganizationsStatistics GetOrganizationStatistics(int organId)
    {
        OrganizationsStatistics statistics = new OrganizationsStatistics();
        Organization organ = GetOrganization(organId);
        if (organ != null)
        {
            statistics.TotalRoutingsCount = organ.SuggestionRoutings.Count();
            statistics.PendingRoutingsCount = organ.SuggestionRoutings.Where(r => r.Status == (int)MyEnums.SuggestionRoutingStatus.Pending).Count();
            statistics.VerifyedRoutingsCount = organ.SuggestionRoutings.Where(r => r.Status == (int)MyEnums.SuggestionRoutingStatus.Verified).Count();
            statistics.RejectedRoutingsCount = organ.SuggestionRoutings.Where(r => r.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected).Count();
        }
        return statistics;
    }

    public void AddSupervisor(Supervisor sup)
    {
        db.Supervisors.InsertOnSubmit(sup);
    }

    public void DeleteSupervisor(Supervisor sup)
    {
        db.Supervisors.DeleteOnSubmit(sup);
    }
    /// ///////////////////////////////////////////////////////
    public void Save()
    {
        db.SubmitChanges();
    }
}