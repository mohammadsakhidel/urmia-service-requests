using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Admins_ToolWindows_AccessOfOrganization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                MembersRepository mr = new MembersRepository();
                Operator oprator = mr.GetOperator(Convert.ToInt32(Request.QueryString["Id"]));
                uc_AccessOfOperator.OperatorID = oprator.ID;
                uc_AccessOfOperator.OperatorAccessRule = oprator.GetOperatorAccessRule();
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender, typeof(Control));
        }
    }
}