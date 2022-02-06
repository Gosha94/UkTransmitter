using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels.DTOs;
using UkTransmitter.Core.Contracts.Services;

namespace Services.UkTransmitter.AuthService
{

    /// <summary>
    /// Служба авторизации, для контроля входа в приложение
    /// </summary>
    public sealed class CustomAuthService : IAuthService
    {
        
        private readonly IUsersRepository<UserUnderAuthDTO, int> _usersRepo;

        #region Constructor

        public CustomAuthService(IUsersRepository<UserUnderAuthDTO, int> usersRepoFromDi)
        {
            this._usersRepo = usersRepoFromDi;
        }

        #endregion

        #region Public API

        public bool TryAuthentificate(UserUnderAuthDTO userForPassAuth) => _usersRepo.FindUserByModel(userForPassAuth);

        public Task<bool> TryAuthentificateAsync(UserUnderAuthDTO userForPassAuth) => Task.Run(() => TryAuthentificate(userForPassAuth));

        #endregion

    }
}