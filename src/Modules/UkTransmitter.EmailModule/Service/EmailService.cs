using System.Threading.Tasks;
using UkTransmitter.EmailModule.Worker;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.EmailModule.Contracts;
using UkTransmitter.BackEnd.Configs.Email;
using UkTransmitter.Core.Contracts;

namespace UkTransmitter.EmailModule.Service
{
    /// <summary>
    /// Служба по работе с Email почтой
    /// </summary>
    public sealed class EmailService : IEmailService
    {

        #region Private Fields

        private readonly IEmailSender _emailSender;
        private readonly IEmailConfiguration _emailConfig;

        #endregion

        #region Public Properties

        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public EmailService(IAttachmentData attachmentData)
        {

            #region Dependency Injection

            var attachData = attachmentData;
            this._emailConfig = new GmailConfiguration();

            #endregion

            var jsonEmailConfig = new JsonEmailSettingsParser(this._emailConfig)
                                    .GetEmailSettingsFromJsonFile();
            
            this._emailSender = new GmailSender(attachData, jsonEmailConfig);

        }

        #endregion

        #region Public API

        /// <summary>
        /// Метод отправки Email сообщения
        /// </summary>
        /// <returns></returns>
        public bool SendEmail()
            => this._emailSender.SendEmailMessage();

        /// <summary>
        /// Асинхронный метод отправки Email сообщения
        /// </summary>
        /// <returns>Успех отправки письма</returns>
        public async Task<bool> SendEmailAsync()
            => await Task.Run(() => this.SendEmail());

        #endregion

    }
}