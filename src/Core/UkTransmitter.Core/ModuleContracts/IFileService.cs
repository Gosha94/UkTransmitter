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

    }
}