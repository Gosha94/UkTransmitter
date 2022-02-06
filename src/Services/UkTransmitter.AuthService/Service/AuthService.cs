using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.Core.Contracts.Services;
using UkTransmitter.Core.CommonModels.DTOs;

namespace UkTransmitter.AuthModule.Service
{

    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class AuthService : IAuthService
    {
        
        private readonly IUsersRepository<UserUnderAuthDTO, int> _usersRepo;

        #region Constructor

        public AuthService(IUsersRepository<UserUnderAuthDTO, int> usersRepoFromDi)
        {
            this._usersRepo = usersRepoFromDi;
        }

        #endregion

        #region Public API

        public UserUnderAuthDTO Authentificate(UserUnderAuthDTO userForPassAuth)
        {
            var isUserCorrect = _usersRepo.FindUserByModel(this._inputUserData);
            return isUserCorrect;
        }

        public Task<UserUnderAuthDTO> AuthentificateAsync(UserUnderAuthDTO userForPassAuth) => Task.Run(() => Authentificate(userForPassAuth));

        #endregion

    }
}