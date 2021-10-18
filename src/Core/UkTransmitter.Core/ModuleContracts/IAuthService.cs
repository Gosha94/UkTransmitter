namespace UkTransmitter.Core.ModuleContracts
{
    /// <summary>
    /// Интерфейс службы аутентификации для изоляции сторонних библиотек
    /// </summary>
    public interface IAuthService
    {

        /// <summary>
        /// Метод проверки существования зарегистрированного пользователя
        /// </summary>
        /// <returns></returns>
        bool IsUserCorrect();
        
    }
}