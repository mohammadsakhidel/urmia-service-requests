using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Shared_SentBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void LoadSentMessages()
    {
        SmsRepository sr = new SmsRepository();
        var sentMessages = sr.GetAllSentMessages();
        PagesCount = sentMessages.Count() / PageSize + (sentMessages.Count() % PageSize == 0 ? 0 : 1);
        list_messages.DataSource = sentMessages.Skip(PageSize * PageIndex).Take(PageSize);
        list_messages.DataBind();
        SetPagerValues();
        if (sentMessages.Count() > 0)
        {
            pnl_list.Visible = true;
            pnl_no_item.Visible = false;
        }
        else
        {
            pnl_list.Visible = false;
            pnl_no_item.Visible = true;
        }
    }

    public int PageIndex
    {
        get
        {
            return (ViewState["PageIndex"] != null ? Convert.ToInt32(ViewState["PageIndex"]) : 0);
        }
        set
        {
            ViewState["PageIndex"] = value.ToString();
        }
    }

    public int PageSize
    {
        get
        {
            return (ViewState["PageSize"] != null ? Convert.ToInt32(ViewState["PageSize"]) : 10);
        }
        set
        {
            ViewState["PageSize"] = value.ToString();
            cmb_PageSize.SelectedValue = PageSize.ToString();
        }
    }

    public int PagesCount
    {
        get
        {
            return (ViewState["PagesCount"] != null ? Convert.ToInt32(ViewState["PagesCount"]) : 1);
        }
        set
        {
            ViewState["PagesCount"] = value.ToString();
            if (PagesCount > 1)
                pnl_pager.Visible = true;
            else
                pnl_pager.Visible = false;
        }
    }

    protected void cmb_PageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            PageSize = Int32.Parse(cmb_PageSize.SelectedValue);
            PageIndex = 0;
            LoadSentMessages();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    private void SetPagerValues()
    {
        lbl_PagerText.Text = "صفحه " + (PageIndex + 1).ToString() + " از " + PagesCount.ToString();
        //////previous button enable:
        if (PageIndex == 0)
            btn_Previous.Enabled = false;
        else if (PageIndex > 0)
            btn_Previous.Enabled = true;
        //////next button enable:
        if (PageIndex < PagesCount - 1)
            btn_Next.Enabled = true;
        else
            btn_Next.Enabled = false;
    }

    protected void btn_Previous_Click(object sender, EventArgs e)
    {
        try
        {
            PageIndex = PageIndex - 1;
            LoadSentMessages();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    protected void btn_Next_Click(object sender, EventArgs e)
    {
        try
        {
            PageIndex = PageIndex + 1;
            LoadSentMessages();
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}