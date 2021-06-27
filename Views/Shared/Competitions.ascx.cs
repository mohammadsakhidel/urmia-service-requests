using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_Competitions : System.Web.UI.UserControl
{
    private List<Competition> competitions = null;
    //********************
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public List<Competition> Competitions
    {
        get
        {
            return competitions;
        }
        set
        {
            competitions = value;
            if (value != null)
            {
                LoadAll(value);
            }
        }
    }
    private void LoadAll(List<Competition> items)
    {
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
        CompetitionsRepository cr = new CompetitionsRepository();
        Competitions = cr.GetAll().ToList();
        LoadAll(Competitions);
    }
    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteItem")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                CompetitionsRepository cr = new CompetitionsRepository();
                cr.Delete(Id);
                cr.Save();
                //////////////////////////
                Competitions = cr.GetAll().ToList();
                LoadAll(Competitions);
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (LinkButton)e.CommandSource, typeof(LinkButton));
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }

}