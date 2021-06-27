using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Models;

public partial class Views_Shared_SearchContacts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                fill_books_combobox();
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    private void fill_books_combobox()
    {
        ContacsRepository cr = new ContacsRepository();
        var books = cr.GetContactBooks();
        cmb_Books.Items.Clear();
        cmb_Books.Items.Add(new ListItem("", "0"));
        foreach (ContactBook book in books)
        {
            cmb_Books.Items.Add(new ListItem(book.Name, book.ID.ToString()));
        }
    }

    protected void cmb_Books_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(2500);
            if (cmb_Books.SelectedIndex > 0)
            {
                fill_fields_combobox(Convert.ToInt32(cmb_Books.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    private void fill_fields_combobox(int bookId)
    {
        ContacsRepository cr = new ContacsRepository();
        ContactBook book = cr.GetContactBook(bookId);
        cmb_Fields.Items.Clear();
        foreach (Field field in book.Fields)
        {
            cmb_Fields.Items.Add(new ListItem(field.Name, field.ID.ToString()));
        }
        Up_FieldSelector.Update();
    }

    public List<Hashtable> Conditions
    {
        get
        {
            return (ViewState["Conditions"] != null ? (List<Hashtable>)ViewState["Conditions"] : new List<Hashtable>());
        }
        set
        {
            ViewState["Conditions"] = value;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable condition = new Hashtable();
            condition["id"] = MyHelper.GetRandomString(15, true);
            condition["book"] = cmb_Books.SelectedValue;
            condition["field"] = cmb_Fields.SelectedValue;
            condition["field_name"] = cmb_Fields.SelectedItem.Text;
            condition["condition"] = cmb_Condition.SelectedValue;
            condition["condition_name"] = cmb_Condition.SelectedItem.Text;
            condition["value"] = tb_Value.Text;
            condition["value_name"] = tb_Value.Text;
            List<Hashtable> conditions = Conditions;
            conditions.Add(condition);
            Conditions = conditions;
            ShowConditions();
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    private void ShowConditions()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(String));
        dt.Columns.Add("field", typeof(String));
        dt.Columns.Add("field_name", typeof(String));
        dt.Columns.Add("condition", typeof(String));
        dt.Columns.Add("condition_name", typeof(String));
        dt.Columns.Add("value", typeof(String));
        dt.Columns.Add("value_name", typeof(String));
        foreach (Hashtable condition in Conditions)
        {
            DataRow row = dt.NewRow();
            row["id"] = condition["id"];
            row["field"] = condition["field"];
            row["field_name"] = condition["field_name"];
            row["condition"] = condition["condition"];
            row["condition_name"] = condition["condition_name"];
            row["value"] = condition["value"];
            row["value_name"] = condition["value_name"];
            dt.Rows.Add(row);
        }
        grid_conditions.DataSource = dt;
        grid_conditions.DataBind();
        Up_Conditions.Update();
        if (dt.Rows.Count > 0)
        {
            cmb_Books.Enabled = false;
            Up_BookSelector.Update();
        }
        else
        {
            cmb_Books.Enabled = true;
            Up_BookSelector.Update();
        }
    }

    protected void grid_conditions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteItem")
            {
                List<Hashtable> conditions = Conditions;
                string Id = e.CommandArgument.ToString();
                for (int i = 0; i < conditions.Count(); i++)
                {
                    if (conditions[i]["id"].ToString() == Id)
                    {
                        conditions.RemoveAt(i);
                    }
                }
                Conditions = conditions;
                ShowConditions();
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    public List<Contact> FoundContacts
    {
        get
        {
            ContacsRepository cr = new ContacsRepository();
            return cr.FindContacts(Conditions);
        }
    }
}