using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_ToolWindows_SendSmsToContacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                PatternsRepository pr = new PatternsRepository();
                Pattern pattern = pr.Get(Convert.ToInt32(Request.QueryString["Id"]));
                uc_SendModule.DefaultText = pattern.Text;
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}