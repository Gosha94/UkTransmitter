using JsonConfigParser.Api.PublicAPI;
using JsonConfigParser.Core.FileConfigs;

namespace UkTransmitter.DataAccess.Services
{

    /// <summary>
    /// Вспомогательная служба для управления строкой подключения к БД
    /// </summary>
    internal sealed class MsSqlConnectionService
    {
        private JsonParsingApi _parsingApi;
        private JsonDBaseConfiguration _configuration;

        public string ConnectionString { get; private set; }

        public MsSqlConnectionService()
        {
            this._parsingApi = new JsonParsingApi();
            
            this._configuration = new JsonDBaseConfiguration();
            
            this.ConnectionString = this._parsingApi.GetDbaseConfigurationData(this._configuration);
        }

        #region Public API

        /// <summary>
        /// Метод выборки из JSON строки подключения к БД
        /// </summary>
        /// <returns>Строка подключения к БД</returns>
        public string GetConnectionString()
            => this.ConnectionString;

        #endregion

    }
}