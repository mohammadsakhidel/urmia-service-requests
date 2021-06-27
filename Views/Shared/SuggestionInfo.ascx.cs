using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_SuggestionInfo : System.Web.UI.UserControl
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
            lbl_info.Text = "از " + value.RecievedMessage.Citizen.MobNumber + " در " + value.RecievedMessage.DateOfRecieveText;
            lbl_persuitCode.Text = "کد رهگیری : " + value.PersuitCode;
            lbl_text.Text = value.RecievedMessage.Text;
            foreach (SuggestionRouting routing in value.SuggestionRoutings.OrderBy(r => r.DateOfRoute))
            {
                //// routing panel:
                Panel pnl_routing = new Panel();
                pnl_routing.CssClass = routing.StatusStyle;
                pnl_routing.Style["margin-top"] = "10px";
                //// info text:
                Panel pnl_info = new Panel();
                Label lbl_routingInfo = new Label();
                lbl_routingInfo.Text = "هدایت شده به سازمان " + routing.Organization.Name + " در تاریخ " + 
                    MyHelper.DateToText(routing.DateOfRoute, MyEnums.DateType.ShortWithTime) + (routing.DateOfAction.HasValue ? " - پاسخ داده شده در " + MyHelper.DateToText(routing.DateOfAction.Value, MyEnums.DateType.ShortWithTime) : "");
                pnl_info.Controls.Add(lbl_routingInfo);
                //// explanation :
                Panel pnl_explanation = new Panel();
                pnl_explanation.Style["margin-top"] = (routing.Explanation != null ? "5px" : "0px");
                pnl_explanation.Style["margin-bottom"] = (!routing.Visible ? "10px" : "0px");
                Label lbl_explanation = new Label();
                lbl_explanation.Text = (routing.Explanation != null ? "توضیحات : " + routing.Explanation : "");
                pnl_explanation.Controls.Add(lbl_explanation);
                ///// visibility:
                Label lbl_visiblity = new Label();
                lbl_visiblity.CssClass = "deleted_label";
                lbl_visiblity.Text = (!routing.Visible ? "حذف شده" : "");
                lbl_visiblity.Visible = !routing.Visible;
                ////// add controls:
                pnl_routing.Controls.Add(pnl_info);
                pnl_routing.Controls.Add(pnl_explanation);
                pnl_routing.Controls.Add(lbl_visiblity);
                pnl_routings.Controls.Add(pnl_routing);
            }
        }
    }
}