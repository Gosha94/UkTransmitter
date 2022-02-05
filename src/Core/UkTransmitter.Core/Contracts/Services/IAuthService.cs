using System.Threading.Tasks;

namespace UkTransmitter.Core.Contracts.Services
{

    /// <summary>
    /// Интерфейс службы аутентификации
    /// </summary>
    public interface IAuthService
    {

        /// <summary>
        /// Метод проверки существования зарегистрированного пользователя
        /// </summary>
        /// <returns></returns>
        bool IsUserCorrect();

        /// <summary>
        /// Асинхронный метод проверки существования зарегистрированного пользователя
        /// </summary>
        /// <returns></returns>
        Task<bool> IsUserCorrectAsync();
        
    }
}