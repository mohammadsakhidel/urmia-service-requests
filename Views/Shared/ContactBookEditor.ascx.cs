using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Data;

public partial class Views_Shared_ContactBookEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public ContactBook ContactBook
    {
        get
        {
            return null;
        }
        set
        {
            if (value != null)
            {
                Action = "edit";
                ContactBookID = value.ID;
                ///////
                tb_Name.Text = value.Name;
                ShowFieldsTable();
            }
            else
            {
                Action = "create";
            }
        }
    }

    int ContactBookID
    {
        get
        {
            return Convert.ToInt32(ViewState["ContactBookID"]);
        }
        set
        {
            ViewState["ContactBookID"] = value;
        }
    }

    public string Action
    {
        get
        {
            return ViewState["Action"].ToString();
        }
        set
        {
            ViewState["Action"] = value;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            ContacsRepository cr = new ContacsRepository();
            if (tb_FieldName.Text.Trim().Length > 0 && tb_FieldIdentifier.Text.Trim().Length > 0)
            {
                ContactBook book = cr.GetContactBook(ContactBookID);
                bool identifierExists = book.Fields.Where(f => f.Identifier.Trim() == tb_FieldIdentifier.Text.Trim()).Count() > 0;
                if (!identifierExists)
                {
                    Field newField = new Field();
                    newField.Name = tb_FieldName.Text;
                    newField.Identifier = tb_FieldIdentifier.Text;
                    book.Fields.Add(newField);
                    cr.Save();
                    /////////////////////////////
                    ShowFieldsTable();
                }
                else
                {
                    throw new Exception("شناسه فیلد وارد شده قبلاً در این دفترچه موجود است");
                }
            }
            else
            {
                throw new Exception("عنوان فیلد و شناسه فیلد را وارد کنید");
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    private void ShowFieldsTable()
    {
        ContacsRepository cr = new ContacsRepository();
        ContactBook book = cr.GetContactBook(ContactBookID);
        grid_items.DataSource = book.Fields;
        grid_items.DataBind();
        tb_FieldName.Text = "";
        tb_FieldIdentifier.Text = "";
        tb_FieldName.Focus();
        up_Fields.Update();
        up_Form.Update();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            if (Action == "create")
            {
                ContactBook book = new ContactBook();
                book.Name = tb_Name.Text;
                book.DateOfCreate = MyHelper.Now;
                //// Save:
                ContacsRepository cr = new ContacsRepository();
                cr.AddBook(book);
                cr.Save();
                ContactBookID = book.ID;
                /////
                MyHelper.MessageBoxShow("با موفقیت انجام شد" , (Control)sender, typeof(Control));
            }
            else if (Action == "edit")
            {
                ContacsRepository cr = new ContacsRepository();
                ContactBook book = cr.GetContactBook(ContactBookID);
                book.Name = tb_Name.Text;
                //// Save:
                cr.Save();
                /////
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
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

    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteItem")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                ContacsRepository cr = new ContacsRepository();
                cr.DeleteField(Id);
                cr.Save();
                ShowFieldsTable();
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (LinkButton)e.CommandSource, typeof(LinkButton));
        }
    }
    
}