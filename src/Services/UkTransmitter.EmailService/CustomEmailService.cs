using System.Threading.Tasks;
using UkTransmitter.EmailService.Models;
using UkTransmitter.EmailService.Configs;
using UkTransmitter.EmailService.Contracts;
using UkTransmitter.Core.Contracts.Services;
using UkTransmitter.EmailService.Workers;

namespace Services.UkTransmitter.EmailService
{
    /// <summary>
    /// Служба по работе с Email почтой
    /// </summary>
    public sealed class CustomEmailService : IEmailService
    {

        #region Private Fields
        
        private readonly IEmailSettings _emailSettings;
        private readonly IEmailApiSettings _emailApiSettings;

        private string _attachmentPath;

        #endregion

        #region Public Properties

        #endregion

        #region Constructor

        public CustomEmailService
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