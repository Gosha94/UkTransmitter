using System.Threading.Tasks;

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

        /// <summary>
        /// Метод отправки Email сообщения
        /// </summary>
        /// <returns></returns>
        bool SendEmail(string attachmentPath);

        /// <summary>
        /// Асинхронный метод отправки Email сообщения
        /// </summary>
        /// <returns>Успех отправки письма</returns>
        Task<bool> SendEmailAsync(string attachmentPath);

    }
}