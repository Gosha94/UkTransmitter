using System;
using System.Linq;
using AesCryptoLib.Api.PublicApi;
using UkTransmitter.Core.Contracts;
using UkTransmitter.DataAccess.Contexts;
using UkTransmitter.DataAccess.Services;
using UkTransmitter.Core.CommonModels.DTOs;

namespace UkTransmitter.DataAccess.Repos
{

    /// <summary>
    /// Репозиторий работает с пользовательскими данными
    /// </summary>
    public class UserAuthRepository : IUsersRepository<UserUnderAuthDTO,int>
    {
        private readonly UserAuthContext _dbaseAuthContext;
        private readonly MsSqlConnectionService _connectionService;
        
        private CryptoApiController _cryptoController;

        public UserAuthRepository()
        {
            this._cryptoController = new CryptoApiController();
            this._connectionService = new MsSqlConnectionService();

            var connString = this._connectionService.GetConnectionString();
            this._dbaseAuthContext = new UserAuthContext(connString);
        }
        
        public UserUnderAuthDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод производит поиск совпадений модели вводимых пользователем данных с данными в БД
        /// </summary>
        /// <param name="userModel">Модель пользователя для авторизации</param>
        /// <returns></returns>
        public bool FindUserByModel(UserUnderAuthDTO userModel)
        {
            // TODO Здесь принимаем риски того, что таблица с данными авторизации небольшая, пока будем перебирать ее полностью,
            // затем дешифровать, далее необходимо Переделать на хранение ХЕШ-СУММЫ и сравнивать, вот же дурная башка !!!
            var userDataListFromDbase = _dbaseAuthContext.UserAuthorizeDataRows.ToList();

            bool resultOfCheck = false;

            foreach (var item in userDataListFromDbase)
            {
                var clearLogin = this._cryptoController.GetDeclassifiedData(item.Login);
                var clearPwd = this._cryptoController.GetDeclassifiedData(item.Pwd);

                if (clearLogin == userModel.UserName && clearPwd == userModel.Pwd)
                {
                    resultOfCheck = true;
                    break;
                }
            }

            return resultOfCheck;
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