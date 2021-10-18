using System;
using System.Linq;
using AesCryptoLib.Api.PublicApi;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.DataAccess.Contexts;
using UkTransmitter.DataAccess.Services;

namespace UkTransmitter.DataAccess.Repos
{
    
    /// <summary>
    /// Репозиторий обрабатывает пользовательские данные
    /// </summary>
    public class UserAuthRepository : IReadOnlyRepository<InputUserAuthModel>
    {
        private CryptoApiController _cryptoController;
        private readonly UserAuthContext _dbaseAuthContext;
        private readonly MsSqlConnectionService _connectionService;

        public UserAuthRepository()
        {
            this._cryptoController = new CryptoApiController();
            this._connectionService = new MsSqlConnectionService();

            var connString = this._connectionService.GetConnectionString();
            this._dbaseAuthContext = new UserAuthContext(connString);
        }

        /// <summary>
        /// Метод производит поиск совпадений модели вводимых пользователем данных с данными в БД
        /// </summary>
        /// <param name="inputUserModel"></param>
        /// <returns></returns>
        public bool FindEqualModelInDatabase(InputUserAuthModel inputUserModel)
            => this._dbaseAuthContext
                .UserAuthorizeDataRows
                .Where(x => x.Login == inputUserModel.InsertedLogin && x.Pwd == inputUserModel.InsertedPwd)
                .Any();

        #region IDisposable Implementation

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._dbaseAuthContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}