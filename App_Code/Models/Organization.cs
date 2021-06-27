using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organization
/// </summary>
namespace Models
{
    public partial class Organization
    {
        public static Organization CurrentUser
        {
            get
            {
                MembersRepository mr = new MembersRepository();
                return mr.GetOrganization(HttpContext.Current.User.Identity.Name);
            }
        }

        public string DateOfCreateText
        {
            get
            {
                return Controllers.ShamsiDateTime.MiladyToShamsi(this.DateOfCreate).ToMediumString();
            }
        }

        public string HtmlOfEditButton
        {
            get
            {
                string url = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditOrganization.aspx") + "?Id=" + this.ID.ToString();
                return "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url + "\" onclick=\"return Open('" + url + "', '', 650, 400);\"></a>";
            }
        }

        public bool IsApproved
        {
            get
            {
                return System.Web.Security.Membership.GetUser(this.UserName).IsApproved;
            }
        }

        public IEnumerable<SuggestionRouting> PendingSuggestions
        {
            get
            {
                return this.SuggestionRoutings.Where(r => r.Status == (int)MyEnums.SuggestionRoutingStatus.Pending);
            }
        }

        public IEnumerable<SuggestionRouting> VerifiedSuggestions
        {
            get
            {
                return this.SuggestionRoutings.Where(r => r.Status == (int)MyEnums.SuggestionRoutingStatus.Verified);
            }
        }

        public IEnumerable<SuggestionRouting> RejectedSuggestions
        {
            get
            {
                return this.SuggestionRoutings.Where(r => r.Status == (int)MyEnums.SuggestionRoutingStatus.Rejected);
            }
        }

        public IEnumerable<SuggestionRouting> OutOfDateSuggestions
        {
            get
            {
                return this.SuggestionRoutings.ToList().Where(r => r.Visible && r.IsOutOfDate);
            }
        }

        public List<string> CellPhonesList
        {
            get
            {
                List<string> mobs = new List<string>();
                var rawList = MyHelper.SplitString(this.CellPhones, ";");
                foreach (string rawNumber in rawList)
                {
                    if (MyHelper.IsMobNumber(rawNumber))
                        mobs.Add(MyHelper.ExtractMobNumber(rawNumber));
                }
                return mobs;
            }
        }

        public int Points { get; set; }
    }
}