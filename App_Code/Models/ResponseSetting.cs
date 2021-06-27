using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class ResponseSetting
    {
        public static ResponseSetting Default
        {
            get
            {
                ResponseSetting defaultSetting = new ResponseSetting();
                defaultSetting.ID = 1;
                ///////
                defaultSetting.PersuitCodeResponse = true;
                defaultSetting.PersuitCodeText = "با تشکر از مشارکت شما، جهت پیگیری موضوع کد رهگیری زیر را پیامک نمایید";
                defaultSetting.CorrectPollAnswerResponse = true;
                defaultSetting.CorrectPollAnswerText = "با تشکر از مشارکت شما، نظر شما با موفقیت ثبت گردید";
                defaultSetting.CorrectCompetitionAnswerResponse = true;
                defaultSetting.CorrectCompetitionAnswerText = "پاسخ شما جهت شرکت در مسابقه با موفقیت ثبت گردید";
                defaultSetting.IncorrectFormatResponse = true;
                defaultSetting.IncorrectFormatText = "پیامک ارسال شده دارای فرمت صحیح نیست، لطفاً مجدداً بررسی و ارسال کنید";
                defaultSetting.IncorrectPollOptionSelectedResponse = true;
                defaultSetting.IncorrectPollOptionSelectedText = "گزینه ارسالی شما صحیح نیست، لطفاً مجدداً بررسی و ارسال کنید";
                defaultSetting.IncorrectCompetitionOptionSelectedResponse = true;
                defaultSetting.IncorrectCompetitionOptionSelectedText = "گزینه ارسالی شما صحیح نیست، لطفاً مجدداً بررسی و ارسال کنید";
                defaultSetting.NoActivePollExistResponse = true;
                defaultSetting.NoActivePollExistText = "با تشکر از مشارکت شما، در حال حاضر نظرسنجی فعالی وجود ندارد";
                defaultSetting.NoActiveCompetitionExistResponse = true;
                defaultSetting.NoActiveCompetitionExistText = "با تشکر از مشارکت شما، در حال حاضر مسابقه فعالی وجود ندارد";
                defaultSetting.IncorrectPersuitCodeResponse = true;
                defaultSetting.IncorrectPersuitCodeText = "شهروند گرامی کد رهگیری ارسالی اشتباه است، لطفاً مجدداً بررسی و ارسال کنید";
                defaultSetting.MonaghesatResponse = true;
                defaultSetting.MonaghesatPattern = "لیست مناقصات فعال:" + "\n" + "--list--";
                defaultSetting.MozaiedatResponse = true;
                defaultSetting.MozaiedatPattern = "لیست مزایدات فعال:" + "\n" + "--list--";
                defaultSetting.IncorrectServiceCodeResponse = true;
                defaultSetting.IncorrectServiceCodeText = "کد سرویس درخواستی اشتباه است، لطفاً مجدداً بررسی و ارسال کنید";
                ///////
                return defaultSetting;
            }
        }

        public static ResponseSetting Load()
        {
            SettingsRepository sr = new SettingsRepository();
            ResponseSetting setting = sr.GetResponseSetting();
            if (setting != null)
                return setting;
            else
                return ResponseSetting.Default;
        }

        public static void Save(ResponseSetting setting)
        {
            SettingsRepository sr = new SettingsRepository();
            sr.DeleteResponseSettings();
            sr.Add(setting);
            sr.Save();
        }
    }
}