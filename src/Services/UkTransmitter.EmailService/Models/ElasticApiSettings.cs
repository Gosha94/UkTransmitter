namespace UkTransmitter.EmailModule.Models
{

    /// <summary>
    /// Класс описывает содержимое Json файла с настройками Api Elastic Email
    /// </summary>
    internal sealed class ElasticApiSettings
    {
        public string ApiUri { get; set; }
        public string ApiKey { get; set; }
    }
}