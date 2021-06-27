using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Controllers;

public partial class Views_Shared_VerifySuggestion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public SuggestionRouting SuggestionRouting
    {
        get
        {
            return null;
        }
        set
        {
            hid_RoutingId.Value = value.ID.ToString();
            lbl_info.Text = "از " + value.Suggestion.RecievedMessage.Citizen.MobNumber + " در " + value.Suggestion.RecievedMessage.DateOfRecieveText;
            lbl_persuitCode.Text = "کد رهگیری : " + value.Suggestion.PersuitCode;
            lbl_text.Text = value.Suggestion.RecievedMessage.Text;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = Convert.ToInt32(hid_RoutingId.Value);
            SuggestionsRepository sr = new SuggestionsRepository();
            SuggestionRouting routing = sr.GetRouting(Id);
            routing.Status = (int)MyEnums.SuggestionRoutingStatus.Verified;
            routing.Explanation = tb_Explanation.Text;
            sr.Save();
            //////// inform verifying:
            InformSetting informSetting = InformSetting.Load();
            if (informSetting.InformVerifying)
            {
                SmsHelper smsHelper = new SmsHelper();
                smsHelper.Send(routing.Suggestion.GetInformOfVerifying(routing), routing.Suggestion.RecievedMessage.Citizen.MobNumber, true);
            }
            MyHelper.MessageBoxShow("با موفقیت انجام شد" , (LinkButton)sender, typeof(LinkButton));
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)sender, typeof(LinkButton));
        }
    }
}