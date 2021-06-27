using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Organizations_Panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                OrganPanelInfo info = new OrganPanelInfo();
                //// info panel:
                lbl_PendingSuggestionsCount.Text = info.PendingSuggestionsCount.ToString();
                pnl_Pendings.Visible = (info.PendingSuggestionsCount > 0 ? true : false);
                lbl_OutOfDatesCount.Text = info.OutOfDateSuggestionsCount.ToString();
                pnl_OutOfDates.Visible = (info.OutOfDateSuggestionsCount > 0 ? true : false);
                pnl_Info.Visible = (pnl_OutOfDates.Visible || pnl_Pendings.Visible ? true : false);
                //// links:
                link_PendingSuggestions.Text = "منتظر پاسخ" + " (" + info.PendingSuggestionsCount.ToString() + ")";
                link_VerifiedSuggestions.Text = "رسیدگی شده" + " (" + info.VerifiedSuggestionsCount.ToString() + ")";
                link_RejectedSuggestions.Text = "رد شده" + " (" + info.RejectedSuggestionsCount.ToString() + ")";
                link_NotRoutedSuggestions.Visible = info.ShowNotRoutedSuggestions;
                if (link_NotRoutedSuggestions.Visible)
                {
                    link_NotRoutedSuggestions.Text = "پیامک های هدایت نشده" + " (" + info.NotRoutedSuggestionsCount.ToString() + ")";
                }
            }
        }
        catch
        {
        }
    }
}