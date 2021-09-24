using System.Diagnostics;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.AuthModule.Service
{
    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class AuthService : IAuthService
    {

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
