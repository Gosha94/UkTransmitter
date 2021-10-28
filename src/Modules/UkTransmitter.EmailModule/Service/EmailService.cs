using UkTransmitter.EmailModule.Worker;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.EmailModule.Contracts;
using UkTransmitter.BackEnd.Configs.Email;
using System.Threading.Tasks;

namespace UkTransmitter.EmailModule.Service
{
    /// <summary>
    /// Служба по работе с Email почтой
    /// </summary>
    public sealed class EmailService : IEmailService
    {

        #region Private Fields

        private IEmailConfiguration _emailConfig;
        private JsonEmailSettingsParser _jsonParser;
        
        #endregion

        #region Public Properties

        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public EmailService()
        {
            this._emailConfig = new GmailConfiguration();
            this._jsonParser = new JsonEmailSettingsParser(this._emailConfig);
        }

        #endregion

        #region Public API

        /// <summary>
        /// Метод отправки Email сообщения
        /// </summary>
        /// <returns></returns>
        public bool SendEmail()
        {

        }

        /// <summary>
        /// Асинхронный метод отправки Email сообщения
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync()
            => await Task.Run(() => this.SendEmail());

        var result = this._jsonParser.GetEmailSettingsFromJsonFile();

        #endregion

        #region Private Methods



        #endregion

    }
}
