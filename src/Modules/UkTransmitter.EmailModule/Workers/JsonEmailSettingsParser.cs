using System.IO;
using Newtonsoft.Json;
using UkTransmitter.EmailModule.Config;
using UkTransmitter.EmailModule.Contracts;

namespace UkTransmitter.EmailModule.Worker
{

    /// <summary>
    /// Класс описывает парсер Json конфигурации
    /// </summary>
    internal sealed class JsonEmailSettingsParser
    {

        private IEmailConfiguration _emailConfiguration;

        public JsonEmailSettingsParser(IEmailConfiguration emailConfigFromDi)
        {
            this._emailConfiguration = emailConfigFromDi;
        }

        public CustomJsonEmailModel GetEmailSettingsFromJsonFile()
        {
            var jsonData = File.ReadAllText(this._emailConfiguration.PathToJsonSettingsFile);
            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonData);
            return myDeserializedClass.CustomJsonEmailSettings;
        }

    }
}