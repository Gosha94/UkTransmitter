namespace UkTransmitter.EmailModule.Models
{

    /// <summary>
    /// Класс описывает корневой элемент Json файла общих почтовых настроек
    /// </summary>
    internal sealed class CommonConfigRootModel
    {
        public CommonEmailSettings CommonEmailSettings { get; set; }
    }
}