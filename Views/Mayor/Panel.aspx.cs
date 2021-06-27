using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Mayor_Panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                SuggestionsRepository sr = new SuggestionsRepository();
                lbl_OutOfDateSuggestionsCount.Text = sr.GetOutOfDateSuggestions().Count().ToString();

            }
        }
        catch(Exception ex) 
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}