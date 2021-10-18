namespace UkTransmitter.Core.ModuleContracts
{
    /// <summary>
    /// Интерфейс службы аутентификации для изоляции сторонних библиотек
    /// </summary>
    public interface IAuthService
    {

        /// <summary>
        /// Метод проверки существования юзера в БД
        /// </summary>
        /// <returns></returns>
        bool IsUserCorrect();
        
    }
}