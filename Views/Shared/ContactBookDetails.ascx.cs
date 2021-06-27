using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_ContactBookDetails : System.Web.UI.UserControl
{
    override protected void OnInit(EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (Request.QueryString["action"] != null && Request.QueryString["actionId"] != null)
        {
            Action = Request.QueryString["action"].ToString();
            ActionID = Convert.ToInt32(Request.QueryString["actionId"]);
        }
        ContacsRepository cr = new ContacsRepository();
        this.ContactBook = cr.GetContactBook(Id);
        base.OnInit(e);
    }

    public string Action
    {
        get
        {
            return (ViewState["Action"] != null ? ViewState["Action"].ToString() : "");
        }
        set
        {
            ViewState["Action"] = value;
        }
    }

    public int ActionID
    {
        get
        {
            return (ViewState["ActionID"] != null ? Convert.ToInt32(ViewState["ActionID"]) : -1);
        }
        set
        {
            ViewState["ActionID"] = value;
        }
    }

    public ContactBook ContactBook
    {
        get
        {
            return null;
        }
        set
        {
            ContactBookID = value.ID;
            if (Action == "delete" && ActionID > 0)
                DeleteContact();
            ShowForm(value.Fields.ToList());
            ShowContacts(value);
        }
    }

    private void DeleteContact()
    {
        ContacsRepository cr = new ContacsRepository();
        cr.DeleteContact(ActionID);
        cr.Save();
        Response.Redirect("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfContactBook.aspx?Id=" + ContactBookID);
    }

    public int ContactBookID
    {
        get
        {
            return (ViewState["ContactBookID"] != null ? Convert.ToInt32(ViewState["ContactBookID"]) : 0);
        }
        set
        {
            ViewState["ContactBookID"] = value;
        }
    }

    private void ShowForm(List<Field> fields)
    {
        HtmlTable tbl_form = new HtmlTable();
        tbl_form.ID = "tbl_form";
        tbl_form.CellPadding = 3;
        tbl_form.CellSpacing = 0;
        tbl_form.Border = 0;
        //////////////// mob:
        //////// Cells:
        HtmlTableCell cell1_mob = new HtmlTableCell();
        cell1_mob.Style["text-align"] = "left";
        cell1_mob.InnerText = "شماره موبایل :";
        HtmlTableCell cell2_mob = new HtmlTableCell();
        cell2_mob.Style["text-align"] = "right";
        TextBox tb_mob = GetTextBox("tb_MobNumber");
        cell2_mob.Controls.Add(tb_mob);
        ///////// Rows:
        HtmlTableRow row_mob = new HtmlTableRow();
        row_mob.Cells.Add(cell1_mob);
        row_mob.Cells.Add(cell2_mob);
        ///////// Table:
        tbl_form.Rows.Add(row_mob);
        //////////////// other fields:
        foreach (Field field in fields)
        {
            //////// Cells:
            HtmlTableCell cell1 = new HtmlTableCell();
            cell1.Style["text-align"] = "left";
            cell1.InnerText = field.Name + " :";
            HtmlTableCell cell2 = new HtmlTableCell();
            cell2.Style["text-align"] = "right";
            TextBox tb = GetTextBox("tb_fieldValue_" + field.ID);
            cell2.Controls.Add(tb);
            ///////// Rows:
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            ///////// Table:
            tbl_form.Rows.Add(row);
        }
        pnl_form.Controls.Add(tbl_form);
    }

    private TextBox GetTextBox(string Id)
    {
        TextBox tb = new TextBox();
        tb.ID = Id;
        tb.CssClass = "textbox";
        tb.Width = new Unit(180);
        return tb;
    }

    private void ShowContacts(ContactBook book)
    {
        pnl_contacts.Controls.Clear();
        pnl_contacts.Controls.Add(book.TableOfContacts);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            ContacsRepository cr = new ContacsRepository();
            ContactBook book = cr.GetContactBook(ContactBookID);
            HtmlTable tbl_form = (HtmlTable)pnl_form.FindControl("tbl_form");
            string mobNumber = ((TextBox)tbl_form.Rows[0].Cells[1].FindControl("tb_MobNumber")).Text;
            bool mobNumberExists = cr.ContactExists(MyHelper.ExtractMobNumber(mobNumber));
            if (MyHelper.IsMobNumber(mobNumber) && !mobNumberExists)
            {
                Contact newContact = new Contact();
                newContact.MobNumber = MyHelper.ExtractMobNumber(mobNumber);
                newContact.DateOfAdd = MyHelper.Now;
                /////// values :
                foreach (Field field in book.Fields)
                {
                    FieldValue fv = new FieldValue();
                    fv.FieldID = field.ID;
                    fv.Value = ((TextBox)tbl_form.Rows[0].Cells[1].FindControl("tb_fieldValue_" + field.ID)).Text;
                    newContact.FieldValues.Add(fv);
                }
                book.Contacts.Add(newContact);
                cr.Save();
                /////////
                ShowContacts(book);
                up_Contacts.Update();
            }
            else
            {
                if (!MyHelper.IsMobNumber(mobNumber))
                    throw new Exception("شماره موبایل وارد شده معتبر نیست");
                else if (mobNumberExists)
                    throw new Exception("شماره موبایل وارد شده قبلاً برای مخاطب ثبت گردیده است");
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
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

}