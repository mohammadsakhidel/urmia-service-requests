using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Operators_ToolWindows_NewCompetition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (uc_Competition.DaysOfActivity > 0)
            {
                ///// poll info:
                Competition com = new Competition();
                com.Subject = uc_Competition.Subject;
                com.SmsText = uc_Competition.SmsText;
                com.DaysOfActivity = uc_Competition.DaysOfActivity;
                com.DateOfCreate = MyHelper.Now;
                com.CreatedBy = User.Identity.Name;
                com.Type = (int)uc_Competition.Type;
                ///// options:
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
                CompetitionsRepository cr = new CompetitionsRepository();
                cr.Add(com);
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