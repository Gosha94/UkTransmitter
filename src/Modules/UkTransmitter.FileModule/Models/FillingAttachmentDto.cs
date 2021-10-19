namespace UkTransmitter.FileModule.Models
{

    /// <summary>
    /// Модель DTO без логики, с данными заполнения файла-вложения
    /// </summary>
    public sealed class FillingAttachmentDto
    {

        /// <summary>
        /// Свойство определяет путь к вновь создаваемому файлу вложения
        /// </summary>
        public string PathNewAttachmentFile { get; set; }

        /// <summary>
        /// Свойство определяет текущий месяц
        /// </summary>
        public int CurrentMonth { get; set; }

        /// <summary>
        /// Свойство определяет массив данных с показаниями счетчиков
        /// </summary>
        public string[] ReceivedFromUserMeteringDataArray { get; set; }
    }

}