using AesCryptoLib.Api.PublicApi;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.AuthModule.Service
{
    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class CustomAuthService : IAuthService
    {
        
        private InputUserAuthModel _inputUserData;
        private CryptoApiController _cryptoController;
        private IReadOnlyRepository<InputUserAuthModel> _userDataRepository;

        #region Constructor

        public CustomAuthService(IReadOnlyRepository<InputUserAuthModel> customRepositoryFromDi, InputUserAuthModel inputUserModel)
        {
            this._inputUserData = inputUserModel;
            this._userDataRepository = customRepositoryFromDi;
            this._cryptoController = new CryptoApiController();

        }

        #endregion

        #region Public API

        public bool IsUserCorrect()
            => this._userDataRepository.FindEqualModelInDatabase(this._inputUserData);

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод шифрует данные пользователя для дальнейшей проверки
        /// </summary>
        private void EncryptInputUserModel()
        {
            this._cryptoController.
        }

        #endregion
    }
}