using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Statistics
/// </summary>
public class Statistics
{
    public static SuggestionsStatistics SuggestionsStatistics
    {
        get
        {
            SuggestionsRepository sr = new SuggestionsRepository();
            return sr.GetSuggestionsStatistics();
        }
    }

    public static OrganizationsStatistics OrganizationStatistics(int organId)
    {
        MembersRepository mr = new MembersRepository();
        return mr.GetOrganizationStatistics(organId);
    }
}

public class SuggestionsStatistics
{
    public int TotalSuggestionsCount { get; set; }
    public int TotalRoutingsCount { get; set; }
    public int VerifyedRoutingsCount { get; set; }
    public int RejectedRoutingsCount { get; set; }
    public int PendingRoutingsCount { get; set; }
    public int NotRoutedSuggestionsCount { get; set; }
}

public class OrganizationsStatistics
{
    public int TotalRoutingsCount { get; set; }
    public int VerifyedRoutingsCount { get; set; }
    public int RejectedRoutingsCount { get; set; }
    public int PendingRoutingsCount { get; set; }
}