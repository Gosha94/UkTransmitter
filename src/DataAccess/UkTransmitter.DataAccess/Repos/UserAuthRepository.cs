using System;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.DataAccess.Contexts;
using UkTransmitter.DataAccess.Services;

namespace UkTransmitter.DataAccess.Repos
{

    /// <summary>
    /// Репозиторий обрабатывает пользовательские данные
    /// </summary>
    public class UserAuthRepository : IReadOnlyRepository<ReadableUserAuthorizeModel>
    {
        private readonly UserAuthContext _dbaseAuthContext;
        private readonly MsSqlConnectionService _connectionService;

        public UserAuthRepository()
        {
            this._connectionService = new MsSqlConnectionService();
            var connString = this._connectionService.GetConnectionString();

            this._dbaseAuthContext = new UserAuthContext(connString);
        }

        public bool FindEqualModelInDatabase(ReadableUserAuthorizeModel userModel)
        {
            throw new System.NotImplementedException();
        }

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