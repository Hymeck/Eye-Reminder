using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeReminder.Enums;
using EyeReminder.Properties;

namespace EyeReminder.Models
{
    public class ConfigurationModel
    {
        private static ConfigurationModel instance;
        public TimeSpan LeftTime { get; set; }
        public TimeSpan BreakTime { get; set; }
        public string BreakTimeNotificationMessage { get; set; }
        public string BreakTimeOverNotificationMessage { get; set; }
        //public Language  Language { get; set; }
        //public ColorSheme AppColorScheme { get; set; }
        //public bool IsNotificationSounded { get; set; }

        private ConfigurationModel()
        {
            //LeftTime = TimeSpan.FromMinutes((double)1 / 12);
            //BreakTime = TimeSpan.FromMinutes((double)1 / 12);
            LeftTime = TimeSpan.FromMinutes(25);
            BreakTime = TimeSpan.FromMinutes(5);
            BreakTimeNotificationMessage = Resources.BreakTimeNotificationMessage;
            BreakTimeOverNotificationMessage = Resources.BreakTimeOverNotificationMessage;
            //Language = Language.English;
            //AppColorScheme = ColorSheme.Default;
            //IsNotificationSounded = false;
        }

        public static ConfigurationModel GetInstance()
        {
            if (instance == null)
                instance = new ConfigurationModel();
            return instance;
        }
    }
}
