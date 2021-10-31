using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.EmailModule.Worker;
using UkTransmitter.EmailModule.Configs;
using UkTransmitter.EmailModule.Workers;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.EmailModule.Contracts;

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

        public EmailService
        (
            IDtoForFillAttachment attachmentDataFromDi,
            ILogService logServiceFromDi
        )
        {

            #region Dependency Injection

            var attachmentData = attachmentDataFromDi;
            this._emailConfig = new GmailConfiguration();

            #endregion

            var jsonEmailConfig = new JsonEmailSettingsParser(this._emailConfig)
                                    .GetEmailSettingsFromJsonFile();

            this._emailSender = new GmailSender(attachmentData, jsonEmailConfig);

        }

        #endregion

        #region Public API
        
        public bool SendEmail()
            => this._emailSender.SendEmailMessage();
        
        public async Task<bool> SendEmailAsync()
            => await Task.Run(() => this.SendEmail());

        #endregion

    }
}