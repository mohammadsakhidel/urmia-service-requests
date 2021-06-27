using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Models;

public partial class Views_Shared_SendModule : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                fill_books_combo();
            }
            catch (Exception exc)
            {
                MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
            }
        }
    }
   
    public MyEnums.TypeOfSend Type
    {
        get
        {
            return (ViewState["TypeOfSend"] != null ? (MyEnums.TypeOfSend)Convert.ToInt32(ViewState["TypeOfSend"]) : MyEnums.TypeOfSend.Free);
        }
        set
        {
            ViewState["TypeOfSend"] = (int)value;
            if (value == MyEnums.TypeOfSend.ContactBook)
            {
                btn_citizen_numbers.Visible = false;
                pnl_CitizensAdvancedSearch.Visible = false;
            }
        }
    }

    public string DefaultText
    {
        get
        {
            return null;
        }
        set
        {
            tb_Text.Text = value;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Type == MyEnums.TypeOfSend.Free)
            {
                string numbers_text = tb_Numbers.Text;
                List<string> numbers = MyHelper.GetLines(numbers_text);
                numbers = ClearNumbers(numbers);
                if (numbers.Count() > 0)
                {
                    string sms_text = tb_Text.Text;
                    //***************** SEND:
                    Controllers.SmsHelper smsHelper = new Controllers.SmsHelper();
                    int _pageSize = 50;
                    int _pagesCount = numbers.Count() / _pageSize + (numbers.Count() % _pageSize == 0 ? 0 : 1);
                    for (int i = 0; i < _pagesCount; i++)
                    {
                        smsHelper.Send(sms_text, numbers.Skip(i * _pageSize).Take(_pageSize).ToList());
                    }
                    //***************** SAVE:
                    SentMessage sentMsg = new SentMessage();
                    sentMsg.Text = sms_text;
                    sentMsg.DateOfSend = MyHelper.Now;
                    foreach (string number in numbers)
                    {
                        SentMessageReciever sentReciever = new SentMessageReciever();
                        sentReciever.MobNumber = number;
                        sentReciever.Status = (int)MyEnums.SentSmsStatus.Sent;
                        sentMsg.SentMessageRecievers.Add(sentReciever);
                    }
                    SmsRepository sr = new SmsRepository();
                    sr.AddSentMessage(sentMsg);
                    sr.Save();
                    ///////////////////////////////////// success message:
                    lbl_Message.Text = "تعداد " + numbers.Count() + " پیامک با موفقیت ارسال گردید.";
                    pnl_Message.CssClass = "center succeed";
                    pnl_Message.Visible = true;
                    up_Message.Update();
                }
                else
                {
                    lbl_Message.Text = "شماره موبایل معتبری وارد نمایید.";
                    pnl_Message.CssClass = "center failed";
                    pnl_Message.Visible = true;
                    up_Message.Update();
                }
            }
            else if (Type == MyEnums.TypeOfSend.ContactBook)
            {
                string numbers_text = tb_Numbers.Text;
                List<string> numbers = MyHelper.GetLines(numbers_text);
                numbers = ClearNumbers(numbers);
                if (numbers.Count() > 0)
                {
                    string sms_text = tb_Text.Text;
                    //***************** SEND:
                    SmsRepository sr = new SmsRepository();
                    Controllers.SmsHelper smsHelper = new Controllers.SmsHelper();
                    for (int i = 0; i < numbers.Count(); i++)
                    {
                        string special_sms_text = sms_text;
                        ////// create special contact sms:
                        ContacsRepository cr = new ContacsRepository();
                        Contact contact = cr.GetContact(numbers[i]);
                        if (contact != null)
                        {
                            var contactFieldIdentifiers = contact.FieldValues.Select(fv => fv.Field.Identifier);
                            foreach (string Identifier in contactFieldIdentifiers)
                            {
                                special_sms_text = special_sms_text.Replace("--" + Identifier + "--", Contact.GetValue(contact.ID, Identifier));
                            }
                        }
                        smsHelper.Send(special_sms_text, numbers[i], false);
                        /////// SAVE :
                        SentMessage sentMsg = new SentMessage();
                        sentMsg.Text = special_sms_text;
                        sentMsg.DateOfSend = MyHelper.Now;
                        SentMessageReciever sentReciever = new SentMessageReciever();
                        sentReciever.MobNumber = numbers[i];
                        sentReciever.Status = (int)MyEnums.SentSmsStatus.Sent;
                        sentMsg.SentMessageRecievers.Add(sentReciever);
                        sr.AddSentMessage(sentMsg);
                    }
                    sr.Save();
                    ///////////////////////////////////// success message:
                    lbl_Message.Text = "تعداد " + numbers.Count() + " پیامک با موفقیت ارسال گردید.";
                    pnl_Message.CssClass = "center succeed";
                    pnl_Message.Visible = true;
                    up_Message.Update();
                }
                else
                {
                    lbl_Message.Text = "شماره موبایل معتبری وارد نمایید.";
                    pnl_Message.CssClass = "center failed";
                    pnl_Message.Visible = true;
                    up_Message.Update();
                }
            }
        }
        catch(Exception ex)
        {
            lbl_Message.Text = ex.Message;
            pnl_Message.CssClass = "center failed";
            pnl_Message.Visible = true;
            up_Message.Update();
        }
    }

    private void AddToNumbersTextbox(string numbers)
    {
        var currentLines = MyHelper.GetLines(tb_Numbers.Text);
        tb_Numbers.Text += (currentLines[currentLines.Count - 1].Trim().Length > 0 ? "\n" : "") + numbers;
        lbl_lines_count.Text = MyHelper.SplitString(numbers, "\n").Count().ToString();
        up_Numbers.Update();
    }

    protected void cmb_Book_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cmb_Book.SelectedIndex > 0)
            {
                ContacsRepository cr = new ContacsRepository();
                int bookId = Convert.ToInt32(cmb_Book.SelectedValue);
                ContactBook book = cr.GetContactBook(bookId);
                AddToNumbersTextbox(book.ContactsLines);
            }
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    private void fill_books_combo()
    {
        ContacsRepository cr = new ContacsRepository();
        var books = cr.GetContactBooks();
        cmb_Book.Items.Clear();
        cmb_Book.Items.Add(new ListItem("", "0"));
        foreach (ContactBook book in books)
        {
            cmb_Book.Items.Add(new ListItem(book.Name, book.ID.ToString()));
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            MembersRepository mr = new MembersRepository();
            List<string> citizenNumbers = mr.GetAllCitizenNumbers();
            AddToNumbersTextbox(ToLines(citizenNumbers));
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    private string ToLines(List<string> list)
    {
        string lines = "";
        for (int i = 0; i < list.Count(); i++)
        {
            lines += list[i] + (i < list.Count() - 1 ? "\n" : "");
        }
        return lines;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> currentLines = MyHelper.GetLines(tb_Numbers.Text);
            currentLines = ClearNumbers(currentLines);
            tb_Numbers.Text = "";
            AddToNumbersTextbox(ToLines(currentLines));
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    private List<string> ClearNumbers(List<string> numbers)
    {
        return numbers.Where(number => MyHelper.IsMobNumber(number)).Select(number => MyHelper.ExtractMobNumber(number)).Distinct().ToList();
    }

    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        try
        {
            List<string> citizenNumbers = uc_SearchCitizen.FoundCitizens.Select(c => c.MobNumber).ToList();
            AddToNumbersTextbox(ToLines(citizenNumbers));
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }

    protected void LinkButton3_Click1(object sender, EventArgs e)
    {
        try
        {
            List<string> contactNumbers = uc_SearchContacts.FoundContacts.Select(c => c.MobNumber).ToList();
            AddToNumbersTextbox(ToLines(contactNumbers));
        }
        catch (Exception exc)
        {
            MyHelper.MessageBoxShow(exc.Message, (Control)sender, typeof(Control));
        }
    }
}