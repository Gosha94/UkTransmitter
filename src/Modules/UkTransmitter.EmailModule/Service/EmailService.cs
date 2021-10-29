using System.Threading.Tasks;
using UkTransmitter.EmailModule.Config;
using UkTransmitter.EmailModule.Worker;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.EmailModule.Contracts;
using UkTransmitter.BackEnd.Configs.Email;

namespace UkTransmitter.EmailModule.Service
{
    /// <summary>
    /// Служба по работе с Email почтой
    /// </summary>
    public sealed class EmailService : IEmailService
    {

        #region Private Fields

        private IEmailConfiguration _emailConfig;
        private IEmailSender _emailSender;
        private JsonEmailSettingsParser _jsonParser;
        private CustomJsonEmailSettings _emailSettings;

        #endregion

        #region Public Properties

        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public EmailService()
        {
            this._emailConfig = new GmailConfiguration();
            this._emailSender = new GmailSender();
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
            this._emailSettings = this._jsonParser.GetEmailSettingsFromJsonFile();
        }

        /// <summary>
        /// Асинхронный метод отправки Email сообщения
        /// </summary>
        /// <returns>Успех отправки письма</returns>
        public async Task<bool> SendEmailAsync()
            => await Task.Run(() => this.SendEmail());

        #endregion

        #region Private Methods



        #endregion

    }
}