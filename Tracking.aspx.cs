using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tracking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_SendTrackingCode_Click(object sender, EventArgs e)
    {
        var trackingCode = tb_TrackingCode.Value;
        SuggestionsRepository sgr = new SuggestionsRepository();
        Suggestion suggestion = (!String.IsNullOrEmpty(trackingCode) ? sgr.Get(trackingCode.ToUpper()) : null);
        if (suggestion != null)
        {
            var stat = suggestion.GetPersuitInformation();

            #region Update Form Values:
            lblErrorMessage.Text = "";
            lblSuccessMessage.Text = stat;
            lblErrorMessage.Visible = false;
            lblSuccessMessage.Visible = true;
            #endregion
        }
        else
        {
            var err_text = "کد رهگیری ارسال شده صحیح نیست.";

            #region Update Form Values:
            lblErrorMessage.Text = err_text;
            lblSuccessMessage.Text = "";
            lblErrorMessage.Visible = true;
            lblSuccessMessage.Visible = false;
            #endregion
        }
    }
}