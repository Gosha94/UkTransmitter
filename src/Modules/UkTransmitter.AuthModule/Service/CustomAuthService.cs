using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.AuthModule.Service
{
    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class CustomAuthService : IAuthService
    {

        private IReadOnlyRepository<> _userDataRepository;

        /*
         Порядок работы службы:
            1) Шифруем связку Логин-Пароль, введенную юзером            
            2) Ищем в БД среди связок Логин-Пароль требуемую, по 100% совпадению
            3) Возвращаем результат поиска, он же модель успеха/провала авторизации
         */

        #region Constructor

        public CustomAuthService(IReadOnlyRepository customRepositoryFromDi)
        {
            this._userDataRepository = customRepositoryFromDi;
        }

        #endregion

        #region Public API

        public bool IsUserCorrect()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
