using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_SuggestionRoutings : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public int Role
    {
        get
        {
            return (ViewState["Role"] != null ? Convert.ToInt32(ViewState["Role"]) : 1);
        }
        set
        {
            ViewState["Role"] = value;
        }
    }

    public int OrganizationID
    {
        get
        {
            return (ViewState["OrganizationID"] != null ? Convert.ToInt32(ViewState["OrganizationID"]) : 0);
        }
        set
        {
            ViewState["OrganizationID"] = value;
        }
    }

    public int Status
    {
        get
        {
            return (ViewState["Status"] != null ? Convert.ToInt32(ViewState["Status"]) : 0);
        }
        set
        {
            ViewState["Status"] = value;
        }
    }

    public void LoadSuggestions()
    {
        int status = Status;
        int organ = OrganizationID;
        SuggestionsRepository sr = new SuggestionsRepository();
        List<SuggestionRouting> items = sr.GetSuggestionRoutings(organ, status).ToList();
        grid_items.DataSource = items;
        grid_items.DataBind();
        if (items.Count > 0)
        {
            pnl_items.Visible = true;
            pnl_no_item.Visible = false;
        }
        else
        {
            pnl_items.Visible = false;
            pnl_no_item.Visible = true;
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
            SuggestionRouting sugRouting = (SuggestionRouting)e.Row.DataItem;
            if (sugRouting != null)
                e.Row.BackColor = sugRouting.StatusColor;
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
                sr.LogicalDeleteRouting(Id);
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