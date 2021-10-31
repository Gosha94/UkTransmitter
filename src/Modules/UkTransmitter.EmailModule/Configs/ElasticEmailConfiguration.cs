using UkTransmitter.EmailModule.Contracts;

namespace UkTransmitter.EmailModule.Configs
{

    /// <summary>
    /// Конфигурация для работы с почтовым API Elastic Email (https://help.elasticemail.com)
    /// </summary>
    internal sealed class ElasticEmailConfiguration : IEmailConfiguration
    {
        public string PathToJsonEmailSettingsFile { get; private set; } = @"D:\UkTransmitterConfig\EmailSettings\UserSettings\CustomEmailSettings.json";
    }
}
