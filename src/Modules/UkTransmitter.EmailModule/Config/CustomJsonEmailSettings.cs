namespace UkTransmitter.EmailModule.Config
{

    /// <summary>
    /// Класс описывает корневой элемент Json файла
    /// </summary>
    public class Root
    {
        public CustomJsonEmailSettings CustomJsonEmailSettings { get; set; }
    }

    /// <summary>
    /// Класс описывает содержимое Json файла с настройками Email письма
    /// </summary>
    public class CustomJsonEmailSettings
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