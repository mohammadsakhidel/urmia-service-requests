using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_CitizenDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Citizen Citizen
    {
        get
        {
            return null;
        }
        set
        {
            SetFormValues(value);
        }
    }

    private void SetFormValues(Citizen citizen)
    {
        lbl_MobNumber.Text = citizen.MobNumber;
        lbl_DateOfAdd.Text = MyHelper.DateToText(citizen.DateOfAdd, MyEnums.DateType.MediumWithTime);
        lbl_Name.Text = (citizen.Name != null ? citizen.Name : "");
        lbl_Gender.Text = (citizen.Gender != null ? citizen.GenderText : "");
        lbl_BornYear.Text = (citizen.BornYear.HasValue ? citizen.BornYear.Value.ToString() : "");
        lbl_Job.Text = (citizen.Job != null ? citizen.Job : "");
        lbl_Zone.Text = (citizen.Zone != null ? citizen.Zone : "");
        lbl_Address.Text = (citizen.Address != null ? citizen.Address : "");
        lbl_SentMessages.Text = citizen.RecievedMessages.Count.ToString();
        lbl_Suggestions.Text = citizen.SuggestionsCount.ToString();
        lbl_Polls.Text = citizen.PollsCount.ToString();
        lbl_Competitions.Text = citizen.CompetitionsCount.ToString();
    }
}