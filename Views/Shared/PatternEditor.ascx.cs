using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Shared_PatternEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Pattern Pattern
    {
        get
        {
            return null;
        }
        set
        {
            tb_Name.Text = value.Name;
            tb_Text.Text = value.Text;
            PatternID = value.ID;
            Action = "edit";
        }
    }

    public string Action
    {
        get
        {
            return ViewState["Action"] != null ? ViewState["Action"].ToString() : "create";
        }
        set
        {
            ViewState["Action"] = value;
        }
    }

    public int PatternID
    {
        get
        {
            return ViewState["PatternID"] != null ? Convert.ToInt32(ViewState["PatternID"]) : 0;
        }
        set
        {
            ViewState["PatternID"] = value;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(2000);
            if (Action == "create")
            {
                Pattern pattern = new Pattern();
                pattern.Name = tb_Name.Text;
                pattern.Text = tb_Text.Text;
                pattern.DateOfCreate = MyHelper.Now;
                PatternsRepository pr = new PatternsRepository();
                pr.Add(pattern);
                pr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
            else if (Action == "edit")
            {
                PatternsRepository pr = new PatternsRepository();
                Pattern pattern = pr.Get(PatternID);
                pattern.Name = tb_Name.Text;
                pattern.Text = tb_Text.Text;
                pr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}