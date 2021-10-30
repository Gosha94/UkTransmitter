namespace UkTransmitter.EmailModule.Config
{

    /// <summary>
    /// Класс описывает корневой элемент Json файла
    /// </summary>
    internal sealed class Root
    {
        public CustomJsonEmailModel CustomJsonEmailSettings { get; set; }
    }

    /// <summary>
    /// Класс описывает содержимое Json файла с настройками Email письма
    /// </summary>
    internal sealed class CustomJsonEmailModel
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