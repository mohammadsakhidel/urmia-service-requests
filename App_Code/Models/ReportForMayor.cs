using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Controllers;

/// <summary>
/// Summary description for ReportForMayor
/// </summary>
public class ReportForMayor
{
	public ReportForMayor(int month, int year)
	{
        MyDatabaseDataContext db = new MyDatabaseDataContext(MyHelper.ConnectionString);
        /////////////////////////////////////////////////////////////////////////////////
        ///// properties:
        var monthRoutings = db.SuggestionRoutings.ToList().Where(rout => ShamsiDateTime.MiladyToShamsi(rout.DateOfRoute).Year == year && ShamsiDateTime.MiladyToShamsi(rout.DateOfRoute).Month == month);
        TotalSuggestionsCount = monthRoutings.Count();
        PendingsCount = monthRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Pending).Count();
        VerifiedsCount = monthRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Verified).Count();
        RejectedsCount = monthRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected).Count();
        var organsByRouting = monthRoutings.Select(rout => rout.Organization).OrderByDescending(organ => organ.SuggestionRoutings.Count());
        var organsByPendings = monthRoutings.Select(rout => rout.Organization).OrderByDescending(organ => organ.SuggestionRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Pending).Count());
        var organsByVerifieds = monthRoutings.Select(rout => rout.Organization).OrderByDescending(organ => organ.SuggestionRoutings.Where(rout => rout.Status == (int)MyEnums.SuggestionRoutingStatus.Verified).Count());
        MaxRoutedOrgan = organsByRouting.Count() > 0 ? organsByRouting.First() : null;
        MaxPendingsOrgan = organsByPendings.Count() > 0 ? organsByPendings.First() : null;
        MaxVerifiedOrgan = organsByVerifieds.Count() > 0 ? organsByVerifieds.First() : null;
	}
    //************************************** PROPERTIES:
    public int TotalSuggestionsCount { get; set; }
    public int PendingsCount { get; set; }
    public int VerifiedsCount { get; set; }
    public int RejectedsCount { get; set; }
    public Models.Organization MaxRoutedOrgan { get; set; }
    public Models.Organization MaxPendingsOrgan { get; set; }
    public Models.Organization MaxVerifiedOrgan { get; set; }
}