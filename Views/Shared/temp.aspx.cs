using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Shared_temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["From"] != null && Request.QueryString["Message"] != null && MyHelper.IsValidMobNumber(Request.QueryString["From"].ToString()))
            {
                string text = "با تشکر از تماس شما با شبکه ارتباطات مردمی مهندس آزاد سخی دل، پیام شما در اسرع وقت بازبینی خواهد شد.";
                string senderTel = MyHelper.ExtractMobNumber(Request.QueryString["From"].ToString());
                OppWebService.Service service = new OppWebService.Service();
                service.SendSMS(AzadAcount.UserName, AzadAcount.Password, AzadAcount.TelNo, new string[] { senderTel }, text);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}

public class AzadAcount
{
    public static string UserName { get { return "azadsms"; } }
    public static string Password { get { return "ramanco"; } }
    public static string TelNo { get { return "3000640900"; } }
}