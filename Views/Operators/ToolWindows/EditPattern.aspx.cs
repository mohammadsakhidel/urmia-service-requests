using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Operators_ToolWindows_NewPattern : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                PatternsRepository pr = new PatternsRepository();
                uc_PatternEditor.Pattern = pr.Get(Id);
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}