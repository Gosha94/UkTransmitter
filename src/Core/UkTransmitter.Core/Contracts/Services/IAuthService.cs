using System.Threading.Tasks;
using UkTransmitter.Core.CommonModels.DTOs;

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
        void Authentificate(ref UserUnderAuthDTO userForPassAuth);

        /// <summary>
        /// Асинхронный метод проверки существования зарегистрированного пользователя
        /// </summary>
        /// <returns></returns>
        Task AuthentificateAsync(ref UserUnderAuthDTO userForPassAuth);
        
    }
}