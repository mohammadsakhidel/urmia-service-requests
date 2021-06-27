using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_PersuitSuggestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Permissions.SuggestionsViewPermission)
                {
                    pnl_Persuit.Visible = true;
                }
                else
                {
                    pnl_Persuit.Visible = false;
                }
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string persuitcode = tb_persuitCode.Text;
            SuggestionsRepository sr = new SuggestionsRepository();
            Suggestion suggestion = sr.Get(persuitcode);
            if (suggestion != null)
            {
                uc_SuggestionInfo.Suggestion = suggestion;
                pnl_FoundSuggestion.Visible = true;
                pnl_no_item.Visible = false;
            }
            else
            {
                pnl_FoundSuggestion.Visible = false;
                pnl_no_item.Visible = true;
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}