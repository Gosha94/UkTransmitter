namespace UkTransmitter.EmailModule.Models
{

    /// <summary>
    /// Класс описывает корневой элемент Json файла общих почтовых настроек
    /// </summary>
    internal sealed class CommonConfigRootModel
    {
        internal CommonEmailSettings CommonEmailSettings { get; set; }
    }
}