using System.Diagnostics;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.AuthModule.Service
{
    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class CustomAuthService : IAuthService
    {

        /*
         Порядок работы службы:
            1) Шифруем связку Логин-Пароль, введенную юзером            
            2) Ищем в БД среди связок Логин-Пароль требуемую, по 100% совпадению
            3) Возвращаем результат поиска, он же модель успеха/провала авторизации
         */


        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #region Constructor

        #endregion

        #region Public API

        public void GoAuth()
        {
            Debug.WriteLine("IAuthService is Registered as AuthService");
        }

        public void SendCall()
        {
            Debug.WriteLine("Hello, call Auth is successfull!");
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
