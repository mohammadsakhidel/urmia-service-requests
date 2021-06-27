using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_RoutedSuggestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Permissions.SuggestionsViewPermission)
                {
                    FillOrganizationsCombobox();
                    uc_SuggestionRoutings.LoadSuggestions();
                }
                else
                {
                    pnl_list.Visible = false;
                }
            }
            catch (Exception exc)
            {
                MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
            }
        }
    }

    private void FillOrganizationsCombobox()
    {
        MembersRepository mr = new MembersRepository();
        var organs = mr.GetAllOrganizations();
        cmb_Organization.Items.Clear();
        cmb_Organization.Items.Add(new ListItem("همه", "0"));
        foreach (Organization organ in organs)
        {
            cmb_Organization.Items.Add(new ListItem(organ.Name, organ.ID.ToString()));
        }
    }

    protected void cmb_Organization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            uc_SuggestionRoutings.OrganizationID = Convert.ToInt32(cmb_Organization.SelectedValue);
            uc_SuggestionRoutings.LoadSuggestions();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    protected void cmb_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            uc_SuggestionRoutings.Status = Convert.ToInt32(cmb_Status.SelectedValue);
            uc_SuggestionRoutings.LoadSuggestions();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}