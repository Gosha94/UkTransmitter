using System.Threading.Tasks;
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
        
        private IUsersRepository<InputUserAuthModel> _userDataRepository;

        public ILogService LogService { get; private set; }

        #region Constructor

        public AuthService(IUsersRepository<InputUserAuthModel> customRepositoryFromDi, InputUserAuthModel inputUserModel, ILogService logServiceFromDi)
        {
            this._userDataRepository = customRepositoryFromDi;
            this._inputUserData = inputUserModel;
            this.LogService = logServiceFromDi;
        }

        #endregion

        #region Public API

        public bool IsUserCorrect()
        {
            var isUserCorrect = this._userDataRepository.FindUserByModel(this._inputUserData);
            this.LogService.WriteIntoLogAsync($"Наличие пользователя с логином: {this._inputUserData.InsertedLogin} в БД: {isUserCorrect} ");
            return isUserCorrect;
        }

        public async Task<bool> IsUserCorrectAsync()
            => await Task.Run(() => IsUserCorrect());

        #endregion

    }
}