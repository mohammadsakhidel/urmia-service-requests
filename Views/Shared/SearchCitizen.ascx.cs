using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Models;

public partial class Views_Shared_SearchCitizen : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public List<Citizen> FoundCitizens
    {
        get
        {
            MembersRepository mr = new MembersRepository();
            return mr.FindCitizens(Conditions);
        }
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

    protected void cmb_Fields_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<int> search_text_indexes = (new int[] { 1, 2, 5, 6, 7 }).ToList();
        List<int> search_digit_indexes = (new int[] { 9, 10, 11, 12 }).ToList();
        List<int> search_date_indexes = (new int[] { 8 }).ToList();
        List<int> search_selection_indexes = (new int[] { 3, 4 }).ToList();
        clear();
        if (search_text_indexes.Contains(Convert.ToInt32(cmb_Fields.SelectedValue)))
        {
            show_text_searching();
        }
        else if (search_date_indexes.Contains(Convert.ToInt32(cmb_Fields.SelectedValue)))
        {
            show_date_searching();
        }
        else if (search_selection_indexes.Contains(Convert.ToInt32(cmb_Fields.SelectedValue)))
        {
            show_selection_searching();
        }
        else if (search_digit_indexes.Contains(Convert.ToInt32(cmb_Fields.SelectedValue)))
        {
            show_digit_searching();
        }
    }

    private void show_digit_searching()
    {
        cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
        cmb_Condition.Items.Add(new ListItem("کوچکتر باشد از", ((int)MyEnums.AdvancedSearchCondition.Fewer).ToString()));
        cmb_Condition.Items.Add(new ListItem("بزرگتر باشد از", ((int)MyEnums.AdvancedSearchCondition.Greater).ToString()));
        Up_ConditionSelector.Update();
        /////////
        tb_Value.Visible = true;
        uc_DateSelector.Visible = false;
        cmb_Value.Visible = false;
        tb_Value.Focus();
        Up_ValueEntering.Update();
    }

    private void show_text_searching()
    {
        cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
        cmb_Condition.Items.Add(new ListItem("مشابه باشد با", ((int)MyEnums.AdvancedSearchCondition.Like).ToString()));
        Up_ConditionSelector.Update();
        /////////
        tb_Value.Visible = true;
        uc_DateSelector.Visible = false;
        cmb_Value.Visible = false;
        tb_Value.Focus();
        Up_ValueEntering.Update();
    }

    private void show_date_searching()
    {
        cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
        cmb_Condition.Items.Add(new ListItem("کوچکتر باشد از", ((int)MyEnums.AdvancedSearchCondition.Fewer).ToString()));
        cmb_Condition.Items.Add(new ListItem("بزرگتر باشد از", ((int)MyEnums.AdvancedSearchCondition.Greater).ToString()));
        Up_ConditionSelector.Update();
        ////
        tb_Value.Visible = false;
        uc_DateSelector.Visible = true;
        cmb_Value.Visible = false;
        Up_ValueEntering.Update();
    }

    private void show_selection_searching()
    {
        cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
        Up_ConditionSelector.Update();
        //////////
        tb_Value.Visible = false;
        uc_DateSelector.Visible = false;
        fill_value_combobox();
        cmb_Value.Visible = true;
        Up_ValueEntering.Update();
    }

    private void clear()
    {
        tb_Value.Text = "";
        cmb_Value.Items.Clear();
        cmb_Condition.Items.Clear();
    }

    private void fill_value_combobox()
    {
        if (Convert.ToInt32(cmb_Fields.SelectedValue) == 3)
        {
            cmb_Value.Items.Clear();
            cmb_Value.Items.Add(new ListItem("مرد", ((int)MyEnums.Gender.Male).ToString()));
            cmb_Value.Items.Add(new ListItem("زن", ((int)MyEnums.Gender.Female).ToString()));
        }
        else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 4)
        {
            cmb_Value.Items.Clear();
            for (int i = 1300; i < 1400; i++)
            {
                cmb_Value.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable condition = new Hashtable();
            condition["id"] = MyHelper.GetRandomString(15, true);
            condition["field"] = cmb_Fields.SelectedValue;
            condition["field_name"] = cmb_Fields.SelectedItem.Text;
            condition["condition"] = cmb_Condition.SelectedValue;
            condition["condition_name"] = cmb_Condition.SelectedItem.Text;
            condition["value"] = (tb_Value.Visible ? tb_Value.Text : (cmb_Value.Visible ? cmb_Value.SelectedValue : (uc_DateSelector.Visible ? uc_DateSelector.SelectedDate_Shamsi.ToString() : "")));
            condition["value_name"] = (tb_Value.Visible ? tb_Value.Text : (cmb_Value.Visible ? cmb_Value.SelectedItem.Text : (uc_DateSelector.Visible ? uc_DateSelector.SelectedDate_Shamsi.ToString() : "")));
            List<Hashtable> conditions = Conditions;
            conditions.Add(condition);
            Conditions = conditions;
            ShowConditions();
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
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
    }
}