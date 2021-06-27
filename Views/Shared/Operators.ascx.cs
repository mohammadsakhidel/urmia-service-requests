using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.Security;

public partial class Views_Shared_Operators : System.Web.UI.UserControl
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
        grid_items.PageIndex = e.NewPageIndex;
        LoadAll();
    }
    public void LoadAll()
    {
        MembersRepository mr = new MembersRepository();
        List<Operator> items = mr.GetAllOperators().ToList();
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
    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteItem")
            {
                int Id = Int32.Parse(e.CommandArgument.ToString());
                //// delete in db:
                MembersRepository mr = new MembersRepository();
                Operator op = mr.GetOperator(Id);
                mr.DeleteOperator(op);
                //// delete acount:
                Membership.DeleteUser(op.UserName, true);
                //// save:
                mr.Save();
                ////////////////////// Message box :
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (LinkButton)e.CommandSource, typeof(LinkButton));
                /////
                LoadAll();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }
    protected void grid_checkbox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox checkbox = (CheckBox)sender;
            Control hidden = MyHelper.FindControl(checkbox.Parent.Controls, typeof(HiddenField));
            if (hidden != null)
            {
                int Id = Int32.Parse(((HiddenField)hidden).Value);
                MembersRepository mr = new MembersRepository();
                Operator op = mr.GetOperator(Id);
                MembershipUser user = Membership.GetUser(op.UserName);
                user.IsApproved = checkbox.Checked;
                Membership.UpdateUser(user);
                /////////////////////
                LoadAll();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}