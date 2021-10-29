using System.Threading.Tasks;

namespace UkTransmitter.Core.ModuleContracts
{
    /// <summary>
    /// Интерфейс службы логирования для изолирования сторонних библиотек
    /// </summary>
    public interface ILogService
    {

        /// <summary>
        /// Запись сообщения об ошибке в Лог
        /// </summary>
        /// <param name="message">Сообщение</param>
        void WriteIntoLog(string message);

        /// <summary>
        /// Асинхронная запись сообщения об ошибке в Лог
        /// </summary>
        /// <param name="message">Сообщение</param>
        Task WriteIntoLogAsync(string message);

    }
}