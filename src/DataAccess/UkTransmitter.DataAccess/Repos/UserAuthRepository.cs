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
    public class UserAuthRepository : IUsersRepository<InputUserAuthModel>
    {
        private readonly UserAuthContext _dbaseAuthContext;
        private readonly MsSqlConnectionService _connectionService;

        private InputUserAuthModel _inputDataModel;
        private CryptoApiController _cryptoController;

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
        public bool FindUserByModel(InputUserAuthModel inputUserModel)
        {
            this._inputDataModel = inputUserModel;
            return CheckModelExistingInDataBase();
        }

        #region Private Methods

        private bool CheckModelExistingInDataBase()
        {
            // TODO Здесь принимаем ириски того, что таблица с данными авторизации небольшая, пока будем перебирать ее полностью,
            // затем дешифровать, далее необходимо Переделать на хранение ХЕШ-СУММЫ и сравнивать, вот же дурная башка !!!
            var userDataListFromDbase = this._dbaseAuthContext.UserAuthorizeDataRows.ToList();
            
            bool resultOfCheck = false;

            foreach (var item in userDataListFromDbase)
            {

                var clearLogin = this._cryptoController.GetDeclassifiedData(item.Login);
                var clearPwd = this._cryptoController.GetDeclassifiedData(item.Pwd);

                if (clearLogin == this._inputDataModel.InsertedLogin && clearPwd == this._inputDataModel.InsertedPwd)
                {
                    resultOfCheck = true;
                    break;
                }
            }

            return resultOfCheck;
        }

        #endregion


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