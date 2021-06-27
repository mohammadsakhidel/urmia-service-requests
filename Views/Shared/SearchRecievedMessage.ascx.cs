using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Models;

public partial class Views_Shared_SearchRecievedMessages : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            condition["value"] = (tb_Text.Visible ? tb_Text.Text : (cmb_ProcessResult.Visible ? cmb_ProcessResult.SelectedValue : (uc_DateSelector.Visible ? uc_DateSelector.SelectedDate_Shamsi.ToString() : "")));
            condition["value_name"] = (tb_Text.Visible ? tb_Text.Text : (cmb_ProcessResult.Visible ? cmb_ProcessResult.SelectedItem.Text : (uc_DateSelector.Visible ? uc_DateSelector.SelectedDate_Shamsi.ToString() : "")));
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

    protected void cmb_Fields_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tb_Text.Text = "";
            cmb_Condition.Items.Clear();
            if (Convert.ToInt32(cmb_Fields.SelectedValue) == 1)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                cmb_Condition.Items.Add(new ListItem("مشابه باشد با", ((int)MyEnums.AdvancedSearchCondition.Like).ToString()));
                Up_ConditionSelector.Update();
                ////
                tb_Text.Visible = true;
                uc_DateSelector.Visible = false;
                cmb_ProcessResult.Visible = false;
                tb_Text.Focus();
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 2)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                cmb_Condition.Items.Add(new ListItem("کوچکتر باشد از", ((int)MyEnums.AdvancedSearchCondition.Fewer).ToString()));
                cmb_Condition.Items.Add(new ListItem("بزرگتر باشد از", ((int)MyEnums.AdvancedSearchCondition.Greater).ToString()));
                Up_ConditionSelector.Update();
                ////
                tb_Text.Visible = false;
                uc_DateSelector.Visible = true;
                cmb_ProcessResult.Visible = false;
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 3)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                Up_ConditionSelector.Update();
                ////
                tb_Text.Visible = false;
                uc_DateSelector.Visible = false;
                cmb_ProcessResult.Visible = true;
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 4)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                cmb_Condition.Items.Add(new ListItem("مشابه باشد با", ((int)MyEnums.AdvancedSearchCondition.Like).ToString()));
                Up_ConditionSelector.Update();
                ////
                tb_Text.Visible = true;
                uc_DateSelector.Visible = false;
                cmb_ProcessResult.Visible = false;
                tb_Text.Focus();
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 5)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                cmb_Condition.Items.Add(new ListItem("مشابه باشد با", ((int)MyEnums.AdvancedSearchCondition.Like).ToString()));
                Up_ConditionSelector.Update();
                ////
                tb_Text.Visible = true;
                uc_DateSelector.Visible = false;
                cmb_ProcessResult.Visible = false;
                tb_Text.Focus();
                Up_ValueEntering.Update();
            }
            else if (Convert.ToInt32(cmb_Fields.SelectedValue) == 6)
            {
                cmb_Condition.Items.Add(new ListItem("مساوی باشد با", ((int)MyEnums.AdvancedSearchCondition.Equal).ToString()));
                cmb_Condition.Items.Add(new ListItem("مشابه باشد با", ((int)MyEnums.AdvancedSearchCondition.Like).ToString()));
                Up_ConditionSelector.Update();
                ////
                tb_Text.Visible = true;
                uc_DateSelector.Visible = false;
                cmb_ProcessResult.Visible = false;
                tb_Text.Focus();
                Up_ValueEntering.Update();
            }
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
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }

    public List<RecievedMessage> FoundRecievedMessages
    {
        get
        {
            List<RecievedMessage> messages = new List<RecievedMessage>();
            SmsRepository sr = new SmsRepository();
            messages = sr.FindRecievedMessages(Conditions).ToList();
            return messages;
        }
    }

}