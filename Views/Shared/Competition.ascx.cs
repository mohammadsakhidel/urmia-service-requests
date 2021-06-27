using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.UI.DataVisualization.Charting;
using Controllers;

public partial class Views_Shared_Competition : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int CompetitionID
    {
        get
        {
            return Int32.Parse(hid_CompetitionID.Value);
        }
        set
        {
            hid_CompetitionID.Value = value.ToString();
        }
    }

    public Competition Competition
    {
        get
        {
            return null;
        }
        set
        {
            if (value != null)
            {
                CompetitionID = value.ID;
                if (value.Type == (int)MyEnums.CompetitionType.Testi)
                {
                    CompetitionsRepository pr = new CompetitionsRepository();
                    foreach (CompetitionOption option in value.CompetitionOptions)
                    {
                        DataPoint point = new DataPoint();
                        point.AxisLabel = option.Text;
                        point.YValues = new double[] { pr.GetAnswersCount(value.ID, option.Identifier) };
                        point.Color = MyHelper.GetRandomColor();
                        point.Font = new System.Drawing.Font("Tahoma", 14);
                        point.IsValueShownAsLabel = true;
                        point.LabelForeColor = System.Drawing.Color.Gray;
                        ch_CompResult.Series["ch_CompResult_Series"].Points.Add(point);
                    }
                    lbl_comp_subject.Text = value.Subject;
                    lbl_total_votes.Text = value.CompetitionAnswers.Count().ToString();
                    lbl_date_of_create.Text = ShamsiDateTime.MiladyToShamsi(value.DateOfCreate).ToMediumString();
                    lbl_date_of_expire.Text = ShamsiDateTime.MiladyToShamsi(value.DateOfExpire).ToMediumString();
                    /////
                    pnl_ActiveCompetition.Visible = true;
                    pnl_no_item.Visible = false;
                    pnl_chart.Visible = true;
                    pnl_list.Visible = false;
                }
                else if (value.Type == (int)MyEnums.CompetitionType.Tashrihi)
                {
                    LoadAnswers(value);
                }
            }
            else
            {
                pnl_ActiveCompetition.Visible = false;
                pnl_no_item.Visible = true;
            }
        }
    }

    private void LoadAnswers(Competition value)
    {
        var answers = value.CompetitionAnswers.OrderByDescending(ans => ans.RecievedMessage.DateOfRecieve);
        PagesCount = answers.Count() / PageSize + (answers.Count() % PageSize == 0 ? 0 : 1);
        list_Answers.DataSource = answers.Skip(PageSize * PageIndex).Take(PageSize);
        list_Answers.DataBind();
        lbl_comp_subject2.Text = value.SmsText;
        SetPagerValues();
        /////
        pnl_ActiveCompetition.Visible = true;
        pnl_no_item.Visible = false;
        pnl_chart.Visible = false;
        pnl_list.Visible = true;
    }

    public int PageIndex
    {
        get
        {
            return Int32.Parse(hid_PageIndex.Value);
        }
        set
        {
            hid_PageIndex.Value = value.ToString();
        }
    }

    public int PageSize
    {
        get
        {
            return Int32.Parse(hid_PageSize.Value);
        }
        set
        {
            hid_PageSize.Value = value.ToString();
            cmb_PageSize.SelectedValue = PageSize.ToString();
        }
    }

    public int PagesCount
    {
        get
        {
            return Int32.Parse(hid_PagesCount.Value);
        }
        set
        {
            hid_PagesCount.Value = value.ToString();
            if (PagesCount > 1)
                pnl_pager.Visible = true;
            else
                pnl_pager.Visible = false;
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
        PageIndex = PageIndex - 1;
        CompetitionsRepository cr = new CompetitionsRepository();
        Competition comp = cr.Get(CompetitionID);
        LoadAnswers(comp);
    }

    protected void btn_Next_Click(object sender, EventArgs e)
    {
        PageIndex = PageIndex + 1;
        CompetitionsRepository cr = new CompetitionsRepository();
        Competition comp = cr.Get(CompetitionID);
        LoadAnswers(comp);
    }

    protected void cmb_PageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageSize = Int32.Parse(cmb_PageSize.SelectedValue);
        PageIndex = 0;
        CompetitionsRepository cr = new CompetitionsRepository();
        Competition comp = cr.Get(CompetitionID);
        LoadAnswers(comp);
    }

    public int ChartWidth
    {
        get
        {
            return (int)ch_CompResult.Width.Value;
        }
        set
        {
            ch_CompResult.Width = new Unit((double)value, UnitType.Pixel);
        }
    }

    public int ChartHeight
    {
        get
        {
            return (int)ch_CompResult.Height.Value;
        }
        set
        {
            ch_CompResult.Height = new Unit((double)value, UnitType.Pixel);
        }
    }
}