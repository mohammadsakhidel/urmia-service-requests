using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using Controllers;
using System.Xml.Serialization;

public struct KeyValueStruct
{
    private int _key;
    private string _val;

    public int Key
    {
        get { return _key; }
        set { _key = value; }
    }
    public string Value
    {
        get { return _val; }
        set { _val = value; }
    }

    public KeyValueStruct(int key, string value)
    {
        _key = key;
        _val = value;
    }
}

[WebService(Namespace = "http://urmia137.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MayorDatesService : System.Web.Services.WebService {

    //***************** Constructor:
    public MayorDatesService()
    {
    }

    //*********************************** Properties:
    private const string _username = "negareh";
    private const string _password = "dotnetcoder";
    //*********************************** private methods:
    private RecievedMessage save_recieved_sms(string briefText, string mayorOrder, string mobile)
    {
        SmsRepository sr = new SmsRepository();
        MembersRepository mr = new MembersRepository();
        RecievedMessage sms = new RecievedMessage();
        string mobNumber = MyHelper.ExtractMobNumber(mobile);
        sms.CitizenID = mr.FindOrCreate(mobNumber).ID;
        sms.Text = briefText + (!String.IsNullOrEmpty(mayorOrder) ? "\n" + "دستور شهردار: " + mayorOrder : "");
        sms.DateOfRecieve = MyHelper.Now;
        sms.Status = (int)MyEnums.RecievedMessageStatus.New;
        sms.ProcessResult = (int)MyEnums.RecievedMessageProcessResult.FromService;
        ////////////////
        sms = sr.Insert(sms);
        ///////
        return sms;
    }
    private void process_recieved_sms(RecievedMessage recieved_sms, int organId, string code)
    {
        InformSetting informSetting = InformSetting.Load();
        SmsHelper smsHelper = new SmsHelper();
        SuggestionsRepository sgr = new SuggestionsRepository();
        //////// save suggestion:
        Suggestion sug = new Suggestion();
        sug.RecievedMessageID = recieved_sms.ID;
        sug.Status = (int)MyEnums.SuggestionStatus.NotRouted;
        sug.PersuitCode = code;
        sug.Visible = true;
        sug = sgr.Insert(sug);
        //////// route suggestion:
        SuggestionRouting sugRouting = new SuggestionRouting();
        sugRouting.OrganizationID = organId;
        sugRouting.DateOfRoute = MyHelper.Now;
        sugRouting.Status = (int)MyEnums.SuggestionRoutingStatus.Pending;
        sugRouting.Visible = true;
        sug.SuggestionRoutings.Add(sugRouting);
        sug.Status = (int)MyEnums.SuggestionStatus.Routed;
        sgr.Save();
        MembersRepository mr = new MembersRepository();
        Organization relatedOrgan = mr.GetOrganization(organId);
        System.IO.File.WriteAllText(Server.MapPath(Urls.TempFiles + "test.txt"), relatedOrgan.Name);
        //////// inform routing:
        if (informSetting.InformRouting)
        {
            string informRoutingText = "شهروند گرامی پیامک شما به سازمان " + relatedOrgan.Name + " ارجاع داده شد:" +
                "\n" + "کد رهگیری: " + sug.PersuitCode;
            smsHelper.Send(informRoutingText, recieved_sms.Citizen.MobNumber, false);
        }
        /////// inform organization operators:
        if (informSetting.InformOrganizationOperators)
        {
            smsHelper.Send(sug.GetInformOfOrganOperators(), relatedOrgan.CellPhonesList);
        }
    }
    //*********************************** Web Methods:
    [WebMethod]
    [XmlInclude(typeof(KeyValueStruct))]
    public KeyValueStruct[] GetOrganizations(string UserName, string Password)
    {

        if (UserName == _username && Password == _password)
        {
            List<KeyValueStruct> organs = null;
            MembersRepository mr = new MembersRepository();
            organs = mr.GetAllOrganizations().Select(org => new KeyValueStruct(org.ID, org.Name)).OrderBy(kv => kv.Value).ToList();
            return organs.ToArray<KeyValueStruct>();
        }
        else
        {
            return null;
        }

    }

    [WebMethod]
    public string ReferToOrganization(string UserName, string Password, int organId, string briefText, string mayorOrder, string mobile, string code)
    {
        try
        {
            if (UserName == _username && Password == _password)
            {
                RecievedMessage recievedMessage = save_recieved_sms(briefText, mayorOrder, mobile);
                process_recieved_sms(recievedMessage, organId, code);
                return "OK";
            }
            else
            {
                return "Invalid Username and Password.";
            }
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }

}
