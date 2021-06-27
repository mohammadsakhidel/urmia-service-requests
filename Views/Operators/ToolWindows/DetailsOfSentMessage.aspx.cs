using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ToolWindows_DetailsOfSentMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SmsRepository sr = new SmsRepository();
            SentMessage sentMessage = sr.GetSentMessage(Convert.ToInt32(Request.QueryString["Id"]));
            uc_SentMessageDetails.SentMessage = sentMessage;
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}