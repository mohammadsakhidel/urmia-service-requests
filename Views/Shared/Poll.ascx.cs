using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using Models;
using Controllers;

public partial class Views_Shared_Poll : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int ChartWidth
    {
        get
        {
            return (int)ch_PollResult.Width.Value;
        }
        set
        {
            ch_PollResult.Width = new Unit((double)value, UnitType.Pixel);
        }
    }

    public int ChartHeight
    {
        get
        {
            return (int)ch_PollResult.Height.Value;
        }
        set
        {
            ch_PollResult.Height = new Unit((double)value, UnitType.Pixel);
        }
    }

    public Models.Poll Poll
    {
        get
        {
            return null;
        }
        set
        {
            if (value != null)
            {
                PollsRepository pr = new PollsRepository();
                foreach (PollOption option in value.PollOptions)
                {
                    DataPoint point = new DataPoint();
                    point.AxisLabel = option.Text;
                    point.YValues = new double[] { pr.GetAnswersCount(value.ID, option.Identifier) };
                    point.Color = MyHelper.GetRandomColor();
                    point.Font = new System.Drawing.Font("Tahoma", 14);
                    point.IsValueShownAsLabel = true;
                    point.LabelForeColor = System.Drawing.Color.Gray;
                    ch_PollResult.Series["ch_PollResult_Series"].Points.Add(point);
                }
                lbl_poll_subject.Text = value.Subject;
                lbl_total_votes.Text = value.PollAnswers.Count().ToString();
                lbl_date_of_create.Text = ShamsiDateTime.MiladyToShamsi(value.DateOfCreate).ToMediumString();
                lbl_date_of_expire.Text = ShamsiDateTime.MiladyToShamsi(value.DateOfExpire).ToMediumString();
                /////
                pnl_ActivePoll.Visible = true;
                pnl_no_item.Visible = false;
            }
            else
            {
                pnl_ActivePoll.Visible = false;
                pnl_no_item.Visible = true;
            }
        }
    }
}