using System;
using UkTransmitter.Core.Contracts;

namespace UkTransmitter.Core.CommonModels.DTOs
{

    /// <summary>
    /// Модель DTO без логики, с данными заполнения файла-вложения
    /// </summary>
    public sealed class DataForFillTemplateDto : IDtoForFillAttachment
    {

        public string PathToNewAttachmentFile { get; set; }

        public DateTime CurrentDate { get; } = DateTime.Now;

        public string[] ReceivedFromUserMeteringDataArray { get; set; }

    }

}