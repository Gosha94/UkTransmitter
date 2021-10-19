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

    }
}