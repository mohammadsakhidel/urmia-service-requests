using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Models;
using Controllers;

public partial class Views_Shared_SearchSuggestion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public MyEnums.TypeOfSuggestionSearch TypeOfSearch
    {
        get
        {
            return (ViewState["TypeOfSearch"] != null ? (MyEnums.TypeOfSuggestionSearch)Convert.ToInt32(ViewState["TypeOfSearch"]) : MyEnums.TypeOfSuggestionSearch.Free);
        }
        set
        {
            ViewState["TypeOfSearch"] = (int)value;
            if (value == MyEnums.TypeOfSuggestionSearch.Organization)
            {
                Hashtable field1 = new Hashtable();
                field1["text"] = "متن پیشنهاد";
                field1["value"] = "1";
                Hashtable field2 = new Hashtable();
                field2["text"] = "وضعیت رسیدگی";
                field2["value"] = "3";
                Hashtable field3 = new Hashtable();
                field3["text"] = "تاریخ ثبت";
                field3["value"] = "4";
                List<Hashtable> fields = new List<Hashtable>();
                fields.Add(field1);
                fields.Add(field2);
                fields.Add(field3);
                SetSearchFields(fields);
            }
        }
    }

    protected void cmb_Fields_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tb_Value.Text = "";
            cmb_Condition.Items.Clear();
            if (Convert.ToInt32(cmb_Fields.SelectedValue) == 1)
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
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 2)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                Up_ConditionSelector.Update();
                //////////
                tb_Value.Visible = false;
                uc_DateSelector.Visible = false;
                FillValueComboboxWithOrganizations();
                cmb_Value.Visible = true;
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 3)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                Up_ConditionSelector.Update();
                //////////
                tb_Value.Visible = false;
                uc_DateSelector.Visible = false;
                FillValueComboboxWithStatuses();
                cmb_Value.Visible = true;
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 4)
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
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    private void FillValueComboboxWithOrganizations()
    {
        MembersRepository mr = new MembersRepository();
        var organs = mr.GetAllOrganizations();
        cmb_Value.Items.Clear();
        foreach (Organization organ in organs)
        {
            cmb_Value.Items.Add(new ListItem(organ.Name, organ.ID.ToString()));
        }
    }

    private void FillValueComboboxWithStatuses()
    {
        cmb_Value.Items.Clear();
        cmb_Value.Items.Add(new ListItem("هدایت نشده", "0"));
        cmb_Value.Items.Add(new ListItem("منتظر پاسخ", ((int)MyEnums.SuggestionRoutingStatus.Pending).ToString()));
        cmb_Value.Items.Add(new ListItem("رد شده", ((int)MyEnums.SuggestionRoutingStatus.Rejected).ToString()));
        cmb_Value.Items.Add(new ListItem("رسیدگی شده", ((int)MyEnums.SuggestionRoutingStatus.Verified).ToString()));
    }

    private void FillValueComboboxWithVisibilities()
    {
        cmb_Value.Items.Clear();
        cmb_Value.Items.Add(new ListItem("قابل روئیت", "1"));
        cmb_Value.Items.Add(new ListItem("حذف شده", "0"));
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
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
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

    public List<Suggestion> FoundSuggestions
    {
        get
        {
            SuggestionsRepository sr = new SuggestionsRepository();
            List<Suggestion> suggestions = new List<Suggestion>();
            if (TypeOfSearch == MyEnums.TypeOfSuggestionSearch.Free)
                suggestions = sr.FindSuggestions(Conditions, null);
            else if (TypeOfSearch == MyEnums.TypeOfSuggestionSearch.Organization)
                suggestions = sr.FindSuggestions(Conditions, Organization.CurrentUser);
            return suggestions;
        }
    }

    public void SetSearchFields(List<Hashtable> fields)
    {
        cmb_Fields.Items.Clear();
        foreach (Hashtable field in fields)
        {
            cmb_Fields.Items.Add(new ListItem(field["text"].ToString(), field["value"].ToString()));
        }
    }
}