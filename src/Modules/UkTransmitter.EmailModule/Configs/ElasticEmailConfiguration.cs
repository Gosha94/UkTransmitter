namespace UkTransmitter.EmailModule.Configs
{

    /// <summary>
    /// Конфигурация для работы с почтовым API Elastic Email (https://help.elasticemail.com)
    /// </summary>
    internal sealed class ElasticEmailConfiguration
    {
        public string PathToEmailApiSettings { get; private set; } = @"D:\UkTransmitterConfig\EmailSettings\ElasticEmailAPI\ClientCredentials\ElasticApiSettings.json";
    }
}