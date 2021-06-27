using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Controllers;

public partial class Views_Shared_RejectSuggestion : System.Web.UI.UserControl
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
            routing.Status = (int)MyEnums.SuggestionRoutingStatus.Rejected;
            routing.Explanation = tb_Explanation.Text;
            sr.Save();
            InformSetting informSetting = InformSetting.Load();
            //////// inform rejection:
            if (informSetting.InformRejection)
            {
                SmsHelper smsHelper = new SmsHelper();
                smsHelper.Send(routing.Suggestion.GetInformOfRejection(routing), routing.Suggestion.RecievedMessage.Citizen.MobNumber, true);
            }
            MyHelper.MessageBoxShow("با موفقیت انجام شد", (LinkButton)sender, typeof(LinkButton));
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)sender, typeof(LinkButton));
        }
    }
}