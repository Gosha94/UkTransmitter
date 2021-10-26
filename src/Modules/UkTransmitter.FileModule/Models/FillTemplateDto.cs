using System;

namespace UkTransmitter.FileModule.Models
{

    /// <summary>
    /// Модель DTO без логики, с данными заполнения файла-вложения
    /// </summary>
    internal sealed class FillTemplateDto
    {

        /// <summary>
        /// Свойство определяет путь к вновь создаваемому файлу вложения
        /// </summary>
        public string PathNewAttachmentFile { get; set; }

        /// <summary>
        /// Свойство определяет текущую дату
        /// </summary>
        public DateTime CurrentDate { get; } = DateTime.Now;
        
        /// <summary>
        /// Свойство определяет массив данных с показаниями счетчиков
        /// </summary>
        public string[] ReceivedFromUserMeteringDataArray { get; set; }
    }

}