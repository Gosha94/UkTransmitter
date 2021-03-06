namespace UkTransmitter.EmailService.Models
{

    /// <summary>
    /// Класс описывает содержимое Json файла с настройками Email письма
    /// </summary>
    internal sealed class CommonEmailSettings
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string MainTo { get; set; }
        public string CopyTo { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

}