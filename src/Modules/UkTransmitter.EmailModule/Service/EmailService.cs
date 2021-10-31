using System.Threading.Tasks;
using UkTransmitter.EmailModule.Models;
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
        
        private readonly IEmailSettings _emailSettings;
        private readonly IEmailApiSettings _emailApiSettings;
        private string _attachmentPath;
        #endregion

        #region Public Properties

        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public EmailService
        (
            ILogService logServiceFromDi
        )
        {

            #region Dependency Injection
            
            this._emailSettings = new CommonEmailConfiguration();
            this._emailApiSettings = new ElasticEmailConfiguration();

            #endregion

        }

        #endregion

        #region Public API
        
        public bool SendEmail(string attachmentPath)
        {

            this._attachmentPath = attachmentPath;

            var jsonParserInstance = new CustomJsonParser(this._emailSettings, this._emailApiSettings);

            var jsonEmailConfig = jsonParserInstance.GetEmailSettingsFromJsonFile();
            var jsonApiConfig = jsonParserInstance.GetEmailApiSettingsFromJsonFile();

            return GetEmailSenderInstance
                (
                    this._attachmentPath,
                    jsonEmailConfig,
                    jsonApiConfig
                )
                .SendEmailMessage();
        }

        
        public async Task<bool> SendEmailAsync(string attachmentPath)
            => await Task.Run(() => this.SendEmail(attachmentPath));

        #endregion

        #region Private Methods

        private ElasticEmailSender GetEmailSenderInstance(string attachmentPath, CommonEmailSettings emailSettings, ElasticApiSettings apiSettings)
            => new ElasticEmailSender(attachmentPath, emailSettings, apiSettings);

        #endregion

    }
}