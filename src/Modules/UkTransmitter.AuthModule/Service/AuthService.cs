using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.AuthModule.Service
{
    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class AuthService : IAuthService
    {
        
        private InputUserAuthModel _inputUserData;
        
        private IReadOnlyRepository<InputUserAuthModel> _userDataRepository;

        public ILogService LogService { get; private set; }

        #region Constructor

        public AuthService(IReadOnlyRepository<InputUserAuthModel> customRepositoryFromDi, ILogService logServiceFromDi, InputUserAuthModel inputUserModel)
        {
            this._inputUserData = inputUserModel;
            this._userDataRepository = customRepositoryFromDi;
            this.LogService = logServiceFromDi;
        }

        #endregion

        #region Public API

        public bool IsUserCorrect()
            => this._userDataRepository.FindEqualModelInDatabase(this._inputUserData);

        #endregion

    }
}