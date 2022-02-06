using System.IO;
using Newtonsoft.Json;
using UkTransmitter.EmailService.Models;
using UkTransmitter.EmailService.Contracts;

namespace UkTransmitter.EmailService.Workers
{

    /// <summary>
    /// Класс описывает парсер Json конфигурации
    /// </summary>
    internal sealed class CustomJsonParser
    {

        private IEmailSettings _emailSettings;
        private IEmailApiSettings _emailApiSettings;

        public CustomJsonParser(IEmailSettings emailSettingsFromDi, IEmailApiSettings apiSettingsFromDi)
        {
            this._emailSettings = emailSettingsFromDi;
            this._emailApiSettings = apiSettingsFromDi;
        }

        public CommonEmailSettings GetEmailSettingsFromJsonFile()
        {
            var jsonData = File.ReadAllText(this._emailSettings.PathToJsonEmailSettingsFile);
            var myDeserializedClass = (CommonConfigRootModel)JsonConvert.DeserializeObject(jsonData, typeof(CommonConfigRootModel));
            return myDeserializedClass.CommonEmailSettings;
        }

        public ElasticApiSettings GetEmailApiSettingsFromJsonFile()
        {
            var jsonData = File.ReadAllText(this._emailApiSettings.PathToJsonEmailApiSettings);
            var myDeserializedClass = (ElasticApiConfigRootModel)JsonConvert.DeserializeObject(jsonData, typeof(ElasticApiConfigRootModel));
            return myDeserializedClass.ElasticApiSettings;
        }

    }
}