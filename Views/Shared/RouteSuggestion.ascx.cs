using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Controllers;

public partial class Views_Shared_RouteSuggestion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public Suggestion Suggestion
    {
        get
        {
            return null;
        }
        set
        {
            hid_Suggestion.Value = value.ID.ToString();
            uc_SuggestionInfo.Suggestion = value;
            MembersRepository mr = new MembersRepository();
            var organs = mr.GetAllOrganizations();
            cmb_Organizations.Items.Clear();
            cmb_Organizations.Items.Add(new ListItem());
            foreach (Organization organ in organs)
            {
                cmb_Organizations.Items.Add(new ListItem(organ.Name, organ.ID.ToString()));
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            InformSetting informSetting = InformSetting.Load();
            SuggestionsRepository sr = new SuggestionsRepository();
            Suggestion suggestion = sr.Get(Convert.ToInt32(hid_Suggestion.Value));
            SuggestionRouting routing = new SuggestionRouting();
            routing.OrganizationID = Convert.ToInt32(cmb_Organizations.SelectedValue);
            routing.DateOfRoute = MyHelper.Now;
            routing.Status = (int)MyEnums.SuggestionRoutingStatus.Pending;
            routing.Visible = true;
            suggestion.Status = (int)MyEnums.SuggestionStatus.Routed;
            suggestion.SuggestionRoutings.Add(routing);
            sr.Save();
            //////// inform routing:
            if (informSetting.InformRouting)
            {
                SmsHelper smsHelper = new SmsHelper();
                smsHelper.Send(suggestion.GetInformOfRouting(routing), suggestion.RecievedMessage.Citizen.MobNumber, true);
            }
            /////// inform organization operators:
            if (informSetting.InformOrganizationOperators)
            {
                MembersRepository mr = new MembersRepository();
                Organization organ = mr.GetOrganization(Convert.ToInt32(cmb_Organizations.SelectedValue));
                SmsHelper smsHelper = new SmsHelper();
                smsHelper.Send(suggestion.GetInformOfOrganOperators(), organ.CellPhonesList);
            }
            //////////////////////////
            uc_SuggestionInfo.Suggestion = suggestion;
            up_Info.Update();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}