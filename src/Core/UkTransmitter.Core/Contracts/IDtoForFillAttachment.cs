using System;

namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает данные для Файла-Вложения
    /// </summary>
    public interface IDtoForFillAttachment
    {

        /// <summary>
        /// Свойство определяет путь к вновь создаваемому файлу вложения
        /// </summary>
        string PathToNewAttachmentFile { get; }

        /// <summary>
        /// Свойство определяет текущую дату
        /// </summary>
        DateTime CurrentDate { get; }

        /// <summary>
        /// Свойство определяет массив данных с показаниями счетчиков
        /// </summary>
        string[] ReceivedFromUserMeteringDataArray { get; }

    }
}
