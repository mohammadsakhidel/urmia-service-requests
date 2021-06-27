using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_Panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminPanelInfo info = new AdminPanelInfo();
            /////// users:
            link_Organizations.Text += " " + "(" + info.OrganizationsCount.ToString() +  ")";
            link_Operators.Text += " " + "(" + info.OperatorsCount.ToString() + ")";
            link_Supervisors.Text += " " + "(" + info.SupervisorsCount.ToString() + ")";
            link_Citizens.Text += " " + "(" + info.CitizensCount.ToString() + ")";
            /////// suggestions:
            link_RoutedSuggestions.Text += " " + "(" + info.RoutedSuggestionsCount.ToString() + ")";
            link_NotRoutedSuggestions.Text += " " + "(" + info.NotRoutedSuggestionsCount.ToString() + ")";
            link_SuggestionsTrash.Text += " " + "(" + info.TrashSuggestionsCount.ToString() + ")";
            /////// polls:
            link_Polls.Text += " " + "(" + info.PollsCount.ToString() + ")";
            if (info.ActivePollAnswersCount >= 0)
                link_ActivePoll.Text += " " + "(نظرات : " + info.ActivePollAnswersCount.ToString() + ")";
            else
            {
                link_ActivePoll.Enabled = false;
                link_ActivePoll.CssClass = "panel_item_link_disabled";
            }
            /////// competitions:
            link_Competitions.Text += " " + "(" + info.CompetitionsCount.ToString() + ")";
            if (info.ActiveCompetitionAnswersCount >= 0)
                link_ActiveCompetition.Text += " " + "(پاسخ ها : " + info.ActiveCompetitionAnswersCount.ToString() + ")";
            else
            {
                link_ActiveCompetition.Enabled = false;
                link_ActiveCompetition.CssClass = "panel_item_link_disabled";
            }
        }
    }
}