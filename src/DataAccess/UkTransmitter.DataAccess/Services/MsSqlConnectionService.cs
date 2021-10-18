using JsonConfigParser.Api.PublicAPI;
using JsonConfigParser.Core.Contracts;
using JsonConfigParser.Core.FileConfigs;

namespace UkTransmitter.DataAccess.Services
{

    /// <summary>
    /// Вспомогательная служба для управления строкой подключения к БД
    /// </summary>
    internal sealed class MsSqlConnectionService
    {
        private JsonParsingApi _parsingApi;
        private IFileConfiguration _configuration;

        public string ConnectionString { get; private set; }

        public MsSqlConnectionService()
        {
            this._parsingApi = new JsonParsingApi();
        }

        #region Public API

        /// <summary>
        /// Метод выборки из JSON строки подключения к БД
        /// </summary>
        /// <returns>Строка подключения к БД</returns>
        public string GetConnectionString()
        {
            this._configuration = new JsonDBaseConfiguration();
            SetConnectionString();
            return this.ConnectionString;
        }

        public string GetSecretData()
        {
            this._configuration = new JsonSaltFileConfiguration();
            SetConnectionString();
            return this.ConnectionString;
        }



        #endregion

        #region Private Methods

        private void SetConnectionString()
        {
            this.ConnectionString = this._parsingApi.GetDbaseConfigurationData(this._configuration);
        }

        #endregion

    }
}