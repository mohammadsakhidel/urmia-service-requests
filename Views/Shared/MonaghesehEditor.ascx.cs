using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_MonaghesehEditor : System.Web.UI.UserControl
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

    public Monagheseh Monagheseh
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
                MonaghesehID = value.ID;
                /////////////
                tb_Shomare.Text = value.Shomare;
                tb_Name.Text = value.Name;
                uc_DateOfStart.SelectedDate_Miladi = value.DateOfStart;
                uc_DateOfEnd.SelectedDate_Miladi = value.DateOfEnd;
            }
        }
    }

    public int MonaghesehID
    {
        get
        {
            return (ViewState["MonaghesehID"] != null ? Convert.ToInt32(ViewState["MonaghesehID"]) : 0);
        }
        set
        {
            ViewState["MonaghesehID"] = value;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Action == "create")
            {
                Monagheseh monagheseh = new Monagheseh();
                monagheseh.Shomare = tb_Shomare.Text;
                monagheseh.Name = tb_Name.Text;
                monagheseh.DateOfStart = uc_DateOfStart.SelectedDate_Shamsi.MiladyDate;
                monagheseh.DateOfEnd = uc_DateOfEnd.SelectedDate_Shamsi.MiladyDate;
                monagheseh.DateOfCreate = MyHelper.Now;
                monagheseh.CreatedBy = HttpContext.Current.User.Identity.Name;
                ServiceRepository sr = new ServiceRepository();
                sr.AddMonagheseh(monagheseh);
                sr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
            else if (Action == "edit")
            {
                ServiceRepository sr = new ServiceRepository();
                Monagheseh monagheseh = sr.GetMonagheseh(MonaghesehID);
                monagheseh.Shomare = tb_Shomare.Text;
                monagheseh.Name = tb_Name.Text;
                monagheseh.DateOfStart = uc_DateOfStart.SelectedDate_Shamsi.MiladyDate;
                monagheseh.DateOfEnd = uc_DateOfEnd.SelectedDate_Shamsi.MiladyDate;
                sr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}