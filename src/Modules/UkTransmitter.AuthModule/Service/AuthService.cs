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

        public async Task<bool> IsUserCorrectAsync()
            => await Task.Run( () =>
            {
                var isUserCorrect =  this._userDataRepository.FindEqualModelInDatabase(this._inputUserData);
                this.LogService.WriteIntoLogAsync($"Наличие пользователя с логином: {this._inputUserData.InsertedLogin} в БД: {isUserCorrect} ");
                return isUserCorrect;
            });

        #endregion

    }
}