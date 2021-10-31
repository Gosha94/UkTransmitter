namespace UkTransmitter.EmailModule.Models
{

    /// <summary>
    /// Класс описывает содержимое Json файла с настройками Api Elastic Email
    /// </summary>
    internal sealed class ElasticApiSettings
    {
        internal string ApiUri { get; set; }
        internal string ApiKey { get; set; }
    }
}