using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_ToolWindows_NewCompetition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            CompetitionsRepository cr = new CompetitionsRepository();
            Competition comp = cr.Get(Id);
            uc_Competition.Competition = comp;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (uc_Competition.DaysOfActivity > 0)
            {
                ///// poll info:
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                CompetitionsRepository cr = new CompetitionsRepository();
                Competition com = cr.Get(Id);
                com.Subject = uc_Competition.Subject;
                com.SmsText = uc_Competition.SmsText;
                com.DaysOfActivity = uc_Competition.DaysOfActivity;
                com.Type = (int)uc_Competition.Type;
                ///// options:
                cr.DeleteOptions(com.CompetitionOptions);
                if (com.Type == (int)MyEnums.CompetitionType.Testi)
                {
                    int i = 1;
                    foreach (string option in uc_Competition.Options)
                    {
                        CompetitionOption comOption = new CompetitionOption();
                        comOption.Text = option;
                        comOption.Identifier = i;
                        com.CompetitionOptions.Add(comOption);
                        i++;
                    }
                }
                ///// save:
                cr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender, typeof(Control));
            }
            else
            {
                throw new Exception("مدت اعتبار را بصورت عدد وارد نمایید");
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}