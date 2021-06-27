using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_NotRoutedSuggestions : System.Web.UI.UserControl
{
    public List<Suggestion> Suggestions
    {
        get
        {
            SuggestionsRepository sr = new SuggestionsRepository();
            return sr.GetNotRoutedSuggestions().ToList();
        }
        set
        {
            LoadAll(value);
        }
    }

    protected void grid_items_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            TableCell td1 = (TableCell)e.Row.Controls[0];
            td1.Attributes["class"] = "grid_pager";
            ///////
            Table table1 = (Table)td1.Controls[0];
            table1.Attributes["class"] = "center";
            table1.Attributes["cellspacing"] = "3";
            ///////
            TableRow tr_LinkCellsContainer = (TableRow)table1.Rows[0];
            /////// ge link td :
            for (int i = 0; i < tr_LinkCellsContainer.Controls.Count; i++)
            {
                TableCell td = (TableCell)tr_LinkCellsContainer.Controls[i];
                try
                {
                    Label span = (Label)td.Controls[0];
                    span.CssClass = "grid_pager_selected_link";
                }
                catch
                {
                    LinkButton link = (LinkButton)td.Controls[0];
                    link.CssClass = "grid_pager_link";
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.CssClass = (e.Row.RowIndex % 2 == 0 ? "grid_row_even" : "grid_row_odd");
        }
    }

    protected void grid_items_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_items.PageIndex = e.NewPageIndex;
        LoadAll(Suggestions);
    }

    private void LoadAll(List<Suggestion> suggestions)
    {
        grid_items.DataSource = suggestions;
        grid_items.DataBind();
        if (suggestions.Count() > 0)
        {
            pnl_no_item.Visible = false;
            grid_items.Visible = true;
        }
        else
        {
            pnl_no_item.Visible = true;
            grid_items.Visible = false;
        }
    }

    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteItem")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                SuggestionsRepository sr = new SuggestionsRepository();
                sr.LogicalDeleteSuggestion(Id);
                sr.Save();
                //////
                LoadAll(sr.GetNotRoutedSuggestions().ToList());
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }
}