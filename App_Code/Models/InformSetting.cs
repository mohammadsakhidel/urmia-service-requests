using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class InformSetting
    {
        public static InformSetting Default
        {
            get
            {
                InformSetting setting = new InformSetting();
                setting.InformRouting = true;
                setting.InformRejection = true;
                setting.InformVerifying = true;
                return setting;
            }
        }

        public static InformSetting Load()
        {
            SettingsRepository sr = new SettingsRepository();
            InformSetting setting = sr.GetInformSetting();
            if (setting != null)
                return setting;
            else
                return InformSetting.Default;
        }

        public static void Save(InformSetting setting)
        {
            SettingsRepository sr = new SettingsRepository();
            sr.DeleteInformSettings();
            sr.Add(setting);
            sr.Save();
        }
    }
}