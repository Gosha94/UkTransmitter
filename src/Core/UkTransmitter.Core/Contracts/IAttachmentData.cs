namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает данные для Файла-Вложения
    /// </summary>
    public interface IAttachmentData
    {

        /// <summary>
        /// Свойство определяет путь к вновь создаваемому файлу вложения
        /// </summary>
        string PathToNewAttachmentFile { get; }

    }
}
