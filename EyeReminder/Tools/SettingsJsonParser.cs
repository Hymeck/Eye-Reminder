using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeReminder.Tools
{
    static class SettingsJsonParser
    {
        private static Dictionary<string, string> settingsDict;
        private static StreamWriter sw = new StreamWriter(Constants.JsonFolder);
        public static void InitSettings()
        {
            settingsDict = new Dictionary<string, string>();
            // read from json file
        }
        //public static Dictionary<string, string> GetSettingsFromJson()
        //{
        //    if (settingsDict == null)
        //    {
        //        // fill dictionary
        //    }
        //    return settingsDict;
        //}

        public static void ChangeValue(string key, string value)
        {
            if (settingsDict == null)
                InitSettings();
            if (!settingsDict.ContainsKey(key))
                throw new ArgumentException($"Dictionary doesn't contains specified key: '{key}'");
            settingsDict[key] = value;
        }

        public static void SaveSettings()
        {
            StringBuilder sb = new StringBuilder("{\n\t");
            foreach (var pair in settingsDict)
            {
                sb.Append($"\"{pair.Key}\": \"{pair.Value}\",\n\r\t");
            }
            sb.Append("}");
            sw.Write(sb.ToString());
        }

        public static Dictionary<string, string> GetJsonSettings() =>
            settingsDict;

        //private void SaveJsonString(string jsonString)
        //{
        //    sw.Write(jsonString);
        //}
    }
}
