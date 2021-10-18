namespace UkTransmitter.Core.ModuleContracts
{
    /// <summary>
    /// Интерфейс почтовой службы для изоляции сторонних библиотек
    /// </summary>
    public interface IEmailService
    {

        /// <summary>
        /// Подключаемая служба логирования
        /// </summary>
        ILogService LogService { get; }

    }
}
