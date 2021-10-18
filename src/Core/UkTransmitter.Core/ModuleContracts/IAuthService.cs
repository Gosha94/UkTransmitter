namespace UkTransmitter.Core.ModuleContracts
{

    /// <summary>
    /// Интерфейс службы аутентификации для изоляции сторонних библиотек
    /// </summary>
    public interface IAuthService
    {

        /// <summary>
        /// Подключаемая служба логирования
        /// </summary>
        ILogService LogService { get; }

        /// <summary>
        /// Метод проверки существования зарегистрированного пользователя
        /// </summary>
        /// <returns></returns>
        bool IsUserCorrect();
        
    }
}