using System.IO;
using Newtonsoft.Json;
using UkTransmitter.EmailModule.Configs;
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

        public IChildrenConfigurationElement GetEmailSettingsFromJsonFile(IRootConfigurationElement rootConfigurationElement)
        {
            
            var jsonData = File.ReadAllText(this._emailConfiguration.PathToJsonSettingsFile);
            var myDeserializedClass = JsonConvert.DeserializeObject<>(jsonData);
            return myDeserializedClass.CustomEmailSettings;
        }

    }
}