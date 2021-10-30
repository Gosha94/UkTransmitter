using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.EmailModule.Worker;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.BackEnd.Configs.Email;
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
        
        public bool SendEmail()
            => this._emailSender.SendEmailMessage();
        
        public async Task<bool> SendEmailAsync()
            => await Task.Run(() => this.SendEmail());

        #endregion

    }
}