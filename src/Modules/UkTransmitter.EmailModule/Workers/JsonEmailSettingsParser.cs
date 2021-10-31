using System.IO;
using Newtonsoft.Json;
using UkTransmitter.EmailModule.Contracts;
using UkTransmitter.EmailModule.Models;

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
            
            var jsonData = File.ReadAllText(this._emailConfiguration.PathToJsonEmailSettingsFile);
            var myDeserializedClass = ()JsonConvert.DeserializeObject(jsonData, typeof(T));
            return myDeserializedClass.CustomEmailSettings;
        }

    }
}