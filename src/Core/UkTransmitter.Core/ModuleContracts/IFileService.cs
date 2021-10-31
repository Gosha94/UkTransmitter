using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;

namespace UkTransmitter.Core.ModuleContracts
{

    /// <summary>
    /// Интерфейс файловой службы для изолирования сторонних библиотек
    /// </summary>
    public interface IFileService
    {

        /// <summary>
        /// Конфигурация вложения
        /// </summary>
        IAttachmentConfiguration AttachmentConfiguration { get; }

        /// <summary>
        /// Конфигурация Шаблона вложения 
        /// </summary>
        ITemplateConfiguration TemplateConfiguration { get; }

        /// <summary>
        /// Подключаемая служба логирования
        /// </summary>
        ILogService LogService { get; }

        /// <summary>
        /// Метод создает файл вложения на диске
        /// </summary>
        string CreateAttachment();

        /// <summary>
        /// Метод асинхронно создает файл вложения на диске
        /// </summary>
        Task<string> CreateAttachmentAsync();

    }
}