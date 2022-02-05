using System.Threading.Tasks;

namespace UkTransmitter.Core.Contracts.Services
{

    /// <summary>
    /// Интерфейс файловой службы
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
        /// Метод создает файл вложения на диске
        /// </summary>
        string CreateAttachment();

        /// <summary>
        /// Метод асинхронно создает файл вложения на диске
        /// </summary>
        Task<string> CreateAttachmentAsync();

    }
}