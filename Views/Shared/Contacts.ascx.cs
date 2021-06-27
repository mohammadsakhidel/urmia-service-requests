using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_Contacts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            LoadBooks();
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
                int bookId = Convert.ToInt32(e.CommandArgument);
                ContacsRepository cr = new ContacsRepository();
                cr.DeleteBook(bookId);
                cr.Save();
                LoadBooks();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }
    public void LoadBooks()
    {
        ContacsRepository cr = new ContacsRepository();
        var books = cr.GetContactBooks();
        grid_items.DataSource = books;
        grid_items.DataBind();
        ////////////////////////////////
        if (books.Count() > 0)
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
}