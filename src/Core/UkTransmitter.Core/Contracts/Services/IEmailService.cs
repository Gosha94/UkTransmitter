using System.Threading.Tasks;

namespace UkTransmitter.Core.Contracts.Services
{

    /// <summary>
    /// Интерфейс почтовой службы
    /// </summary>
    public interface IEmailService
    {

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