using System.IO;
using Newtonsoft.Json;
using UkTransmitter.EmailModule.Config;

namespace UkTransmitter.EmailModule.Worker
{

    /// <summary>
    /// Класс описывает парсер Json конфигурации
    /// </summary>
    internal sealed class JsonEmailSettingsParser
    {
        public Root GetEmailSettingsFromJsonFile()
        {
            var jsonData = File.ReadAllText(@"D:\UkTransmitterConfig\EmailSettings\UserSettings\CustomEmailSettings.json");
            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonData);
            return myDeserializedClass;
        }
    }
}
