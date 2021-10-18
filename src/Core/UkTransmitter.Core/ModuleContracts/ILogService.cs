namespace UkTransmitter.Core.ModuleContracts
{
    /// <summary>
    /// Интерфейс службы логирования для изолирования сторонних библиотек
    /// </summary>
    public interface ILogService
    {

        void WriteIntoLog();
    }
}