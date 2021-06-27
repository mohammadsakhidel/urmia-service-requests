using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_SuggestionsTrash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadSuggestions();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    protected void grid_routed_items_RowCreated(object sender, GridViewRowEventArgs e)
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
            SuggestionRouting sugRouting = (SuggestionRouting)e.Row.DataItem;
            if (sugRouting != null)
                e.Row.BackColor = sugRouting.StatusColor;
        }
    }

    protected void grid_routed_items_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grid_routed_items.PageIndex = e.NewPageIndex;
            LoadSuggestions();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    protected void grid_routed_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteItem")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                SuggestionsRepository sr = new SuggestionsRepository();
                sr.DeleteRouting(Id);
                sr.Save();
                LoadSuggestions();
            }
            else if (e.CommandName == "RestoreItem")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                SuggestionsRepository sr = new SuggestionsRepository();
                sr.RestoreSuggestionRouting(Id);
                sr.Save();
                LoadSuggestions();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }

    private void LoadSuggestions()
    {
        if (cmb_Type.SelectedValue == "1")
        {
            SuggestionsRepository sr = new SuggestionsRepository();
            var deletedItems = sr.GetDeletedRoutings();
            grid_routed_items.DataSource = deletedItems;
            grid_routed_items.DataBind();
            if (deletedItems.Count() > 0)
            {
                pnl_routed_items.Visible = true;
                pnl_notRouted_items.Visible = false;
                pnl_no_item.Visible = false;
            }
            else
            {
                pnl_routed_items.Visible = false;
                pnl_notRouted_items.Visible = false;
                pnl_no_item.Visible = true;
            }
        }
        else if (cmb_Type.SelectedValue == "2")
        {
            SuggestionsRepository sr = new SuggestionsRepository();
            var deletedItems = sr.GetDeletedSuggestions();
            grid_items.DataSource = deletedItems;
            grid_items.DataBind();
            if (deletedItems.Count() > 0)
            {
                pnl_routed_items.Visible = false;
                pnl_notRouted_items.Visible = true;
                pnl_no_item.Visible = false;
            }
            else
            {
                pnl_routed_items.Visible = false;
                pnl_notRouted_items.Visible = false;
                pnl_no_item.Visible = true;
            }
        }
    }

    protected void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hid_Type.Value = cmb_Type.SelectedValue;
            LoadSuggestions();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
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
        try
        {
            grid_items.PageIndex = e.NewPageIndex;
            LoadSuggestions();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
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
                sr.DeleteSuggestion(Id);
                sr.Save();
                LoadSuggestions();
            }
            else if (e.CommandName == "RestoreItem")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                SuggestionsRepository sr = new SuggestionsRepository();
                sr.RestoreSuggestion(Id);
                sr.Save();
                LoadSuggestions();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }
}