namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает конфигурацию файла-вложения с показаниями счетчиков
    /// </summary>
    public interface IAttachmentConfiguration
    {

        /// <summary>
        /// Свойство описывает Путь к Основному Каталогу с данными
        /// </summary>
        string PathToMainCatalog { get; }

        /// <summary>
        /// Свойство описывает Путь к Каталогу с Вложениями на отправку
        /// </summary>
        string PathToAttachmentsCatalog { get; }

    }
}