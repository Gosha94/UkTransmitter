using System;
using UkTransmitter.Core.Contracts;

namespace UkTransmitter.Core.CommonModels.DTOs
{

    /// <summary>
    /// Модель DTO без логики, с данными заполнения файла-вложения
    /// </summary>
    public sealed class DataForFillTemplateDto : IAttachmentData
    {

        public string PathToNewAttachmentFile { get; set; }

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