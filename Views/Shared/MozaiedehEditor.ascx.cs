using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_MozaiedehEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Action
    {
        get
        {
            return (ViewState["Action"] != null ? ViewState["Action"].ToString() : "create");
        }
        set
        {
            ViewState["Action"] = value;
        }
    }

    public Mozaiedeh Mozaiedeh
    {
        get
        {
            return null;
        }
        set
        {
            if (value != null)
            {
                ViewState["Action"] = "edit";
                MozaiedehID = value.ID;
                /////////////
                tb_Shomare.Text = value.Shomare;
                tb_Name.Text = value.Name;
                uc_DateOfStart.SelectedDate_Miladi = value.DateOfStart;
                uc_DateOfEnd.SelectedDate_Miladi = value.DateOfEnd;
            }
        }
    }

    public int MozaiedehID
    {
        get
        {
            return (ViewState["MozaiedehID"] != null ? Convert.ToInt32(ViewState["MozaiedehID"]) : 0);
        }
        set
        {
            ViewState["MozaiedehID"] = value;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Action == "create")
            {
                Mozaiedeh mozaiedeh = new Mozaiedeh();
                mozaiedeh.Shomare = tb_Shomare.Text;
                mozaiedeh.Name = tb_Name.Text;
                mozaiedeh.DateOfStart = uc_DateOfStart.SelectedDate_Shamsi.MiladyDate;
                mozaiedeh.DateOfEnd = uc_DateOfEnd.SelectedDate_Shamsi.MiladyDate;
                mozaiedeh.DateOfCreate = MyHelper.Now;
                mozaiedeh.CreatedBy = HttpContext.Current.User.Identity.Name;
                ServiceRepository sr = new ServiceRepository();
                sr.AddMozaiedeh(mozaiedeh);
                sr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
            else if (Action == "edit")
            {
                ServiceRepository sr = new ServiceRepository();
                Mozaiedeh mozaiedeh = sr.GetMozaiedeh(MozaiedehID);
                mozaiedeh.Shomare = tb_Shomare.Text;
                mozaiedeh.Name = tb_Name.Text;
                mozaiedeh.DateOfStart = uc_DateOfStart.SelectedDate_Shamsi.MiladyDate;
                mozaiedeh.DateOfEnd = uc_DateOfEnd.SelectedDate_Shamsi.MiladyDate;
                sr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}