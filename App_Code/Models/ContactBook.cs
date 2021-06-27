using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Models
{
    public partial class ContactBook
    {
        public string DateOfCreateText
        {
            get
            {
                return MyHelper.DateToText(this.DateOfCreate, MyEnums.DateType.MediumWithTime);
            }
        }

        public string HtmlOfGridActions
        {
            get
            {
                string html = "";
                string url_details = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfContactBook.aspx") + "?Id=" + this.ID.ToString();
                string url_edit = MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/EditContactBook.aspx") + "?Id=" + this.ID.ToString();
                html =
                    (Permissions.SendSmsWritePermission ?
                    "<a class=\"grid_button grid_details\" title=\"مخاطبین\" href=\"" + url_details + "\" onclick=\"return Open('" + url_details + "', '', 750, 550);\"></a>" +
                    "<a class=\"grid_button grid_edit\" title=\"ویرایش\" href=\"" + url_edit + "\" onclick=\"return Open('" + url_edit + "', '', 700, 500);\" style=\"margin-right : 5px;\"></a>" 
                    : "");
                return html;
            }
        }

        public string ContactsLines
        {
            get
            {
                string lines = "";
                for (int i = 0; i < Contacts.Count(); i++)
                {
                    Contact contact = Contacts[i];
                    lines += contact.MobNumber + (i < Contacts.Count() - 1 ? "\n" : "");
                }
                return lines;
            }
        }

        public HtmlTable TableOfContacts
        {
            get
            {
                return ContactBook.GetTableOfContacts(this);
            }
        }

        public static HtmlTable GetTableOfContacts(ContactBook book)
        {
            HtmlTable tbl_contacts = new HtmlTable();
            tbl_contacts.CellPadding = 0;
            tbl_contacts.CellSpacing = 0;
            tbl_contacts.Attributes["class"] = "grid";
            tbl_contacts.Style["width"] = "100%";
            tbl_contacts.Style["border-collapse"] = "collapse";
            //////********************************grid header:
            HtmlTableRow headerRow = new HtmlTableRow();
            headerRow.Attributes["class"] = "grid_header";
            //mobnumber:
            HtmlTableCell headerCell_mob = new HtmlTableCell();
            headerCell_mob.Attributes["scope"] = "col";
            headerCell_mob.InnerText = "شماره موبایل";
            headerRow.Cells.Add(headerCell_mob);
            //other fields:
            foreach (Field field in book.Fields)
            {
                HtmlTableCell headerCell = new HtmlTableCell();
                headerCell.Attributes["scope"] ="col";
                headerCell.InnerText = field.Name;
                headerRow.Cells.Add(headerCell);
            }
            //delete field:
            HtmlTableCell headerCell_delete = new HtmlTableCell();
            headerCell_delete.Attributes["scope"] = "col";
            headerCell_delete.InnerText = "";
            headerRow.Cells.Add(headerCell_delete);
            ////
            tbl_contacts.Rows.Add(headerRow);
            //////********************************grid rows:
            int rowIndex = 0;
            foreach (Contact contact in book.Contacts)
            {
                HtmlTableRow contactRow = new HtmlTableRow();
                contactRow.Attributes["class"] = (rowIndex % 2 == 0 ? "grid_row_even" : "grid_row_odd");
                //mob:
                HtmlTableCell contactCell_mob = new HtmlTableCell();
                contactCell_mob.Attributes["class"] = "grid_item";
                contactCell_mob.InnerText = contact.MobNumber;
                contactRow.Cells.Add(contactCell_mob);
                //other:
                foreach (Field field in book.Fields)
                {
                    HtmlTableCell contactCell = new HtmlTableCell();
                    contactCell.Attributes["class"] = "grid_item";
                    contactCell.InnerText = Contact.GetValue(contact.ID, field.Identifier);
                    contactRow.Cells.Add(contactCell);
                }
                //delete:
                HtmlTableCell contactCell_del = new HtmlTableCell();
                contactCell_del.Attributes["class"] = "grid_item";
                contactCell_del.InnerHtml = "<a class=\"grid_button grid_delete\" href=\"" + MyHelper.Url("~/Views/" + MyRoles.FolderName + "/ToolWindows/DetailsOfContactBook.aspx") + "?Id="+ book.ID +"&action=delete&actionId=" + contact.ID + "\"></a>";
                contactRow.Cells.Add(contactCell_del);
                //////
                tbl_contacts.Rows.Add(contactRow);
                rowIndex++;
            }
            return tbl_contacts;
        }

    }
}