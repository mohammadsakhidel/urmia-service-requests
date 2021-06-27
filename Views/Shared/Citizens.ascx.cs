using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_Citizens : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grid_items_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_items.PageIndex = e.NewPageIndex;
        LoadFounds();
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LoadFounds();
    }

    private void LoadFounds()
    {
        var founds = uc_SearchCitizen.FoundCitizens; ;
        grid_items.DataSource = founds;
        grid_items.DataBind();
        if (founds.Count() > 0)
        {
            pnl_Items.Visible = true;
            pnl_no_item.Visible = false;
        }
        else
        {
            pnl_Items.Visible = false;
            pnl_no_item.Visible = true;
        }
    }
}