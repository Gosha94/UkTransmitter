namespace UkTransmitter.Core.ModuleContracts
{

    /// <summary>
    /// Интерфейс файловой службы для изолирования сторонних библиотек
    /// </summary>
    public interface IFileService
    {

        /// <summary>
        /// Подключаемая служба логирования
        /// </summary>
        ILogService LogService { get; }

        /// <summary>
        /// Метод-обработчик события существования вложения
        /// </summary>
        void AttachmentExistHandler();

        /// <summary>
        /// Метод-обработчик события создания директории
        /// </summary>
        void DirectoryWasCreatedHandler();

    }
}