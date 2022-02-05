using UkTransmitter.EmailModule.Contracts;

namespace UkTransmitter.EmailModule.Configs
{

    /// <summary>
    /// Конфигурация для работы с почтовым API Elastic Email (https://help.elasticemail.com)
    /// </summary>
    internal sealed class ElasticEmailConfiguration : IEmailApiSettings
    {
        public string PathToJsonEmailApiSettings { get; private set; } = @"D:\UkTransmitterConfig\EmailSettings\ElasticEmailAPI\ClientCredentials\ElasticApiSettings.json";
    }
}