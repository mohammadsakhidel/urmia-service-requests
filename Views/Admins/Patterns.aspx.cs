using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_Patterns : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                uc_Patterns.LoadPatterns();
            }
            catch (Exception ex)
            {
                MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
            }
        }
    }
}