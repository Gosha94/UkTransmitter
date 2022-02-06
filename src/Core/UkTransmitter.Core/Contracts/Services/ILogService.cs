using System.Threading.Tasks;

namespace UkTransmitter.Core.Contracts.Services
{
    /// <summary>
    /// Интерфейс службы логирования
    /// </summary>
    public interface ILogService
    {

        /// <summary>
        /// Запись сообщения об ошибке в Лог
        /// </summary>
        /// <param name="message">Сообщение</param>
        void WriteLog(string message);

        /// <summary>
        /// Асинхронная запись сообщения об ошибке в Лог
        /// </summary>
        /// <param name="message">Сообщение</param>
        Task WriteLogAsync(string message);

    }
}