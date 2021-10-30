using System;
using MimeKit;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Threading;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using UkTransmitter.Core.Contracts;
using UkTransmitter.EmailModule.Config;
using UkTransmitter.BackEnd.Configs.Email;
using UkTransmitter.EmailModule.Contracts;

namespace UkTransmitter.EmailModule.Workers
{

    /// <summary>
    /// Класс описывает Отправлятор Писем при помощи Gmail API
    /// </summary>
    internal sealed class GmailSender : IEmailSender
    {

        #region Private Fields

        private GmailService _gmailService;
        private IDtoForFillAttachment _attachmentData;
        private CustomJsonEmailModel _emailSettings;

        #endregion

        #region Public Properties

        #endregion

        #region Constructor

        public GmailSender(IDtoForFillAttachment attachmentDataFromDi, CustomJsonEmailModel jsonEmailSettings)
        {
            this._attachmentData = attachmentDataFromDi;
            this._emailSettings = jsonEmailSettings;

            InitializeGmailService();
        }
        
        #endregion

        #region Public API

        public bool SendEmailMessage()
        {
            
            var tempMessage = CreateMimeMessage(this._attachmentData.PathToNewAttachmentFile);
            var readyToSendMessage = ClearIncorrectSymbolsInMessage(tempMessage);
            
            // TODO: Вынести константы в конфигу
            _gmailService.Users.Messages.Send(readyToSendMessage, "Георгий").Execute();
            
            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод инициализирует службу Google Mail
        /// </summary>
        private void InitializeGmailService()
        {
            UserCredential credential;
            
            using ( FileStream stream = new FileStream(
                                            GoogleOAuth2Configuration.ClientInfo,
                                            FileMode.Open,
                                            FileAccess.Read
                                            )
                  )
            {
                var folderPath = GoogleOAuth2Configuration.CredentialsInfo;
                var filePath = Path.Combine(folderPath, "APITokenCredentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    GoogleOAuth2Configuration.Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(filePath, true)).Result;
            }
            // Create Gmail API service.
            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = GoogleOAuth2Configuration.ApplicationName,
            });

            this._gmailService = service;
        }

        /// <summary>
        /// Метод подготовки текста сообщения
        /// </summary>
        /// <returns>Закодированное сообщение со спец. символами</returns>
        private MimeMessage CreateMimeMessage(string pathToAttachment)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = this._emailSettings.Subject;
            mail.From = new MailAddress(this._emailSettings.From);
            mail.BodyEncoding = Encoding.UTF8;
            mail.Body = this._emailSettings.Body;
            mail.IsBodyHtml = true;
            
            string pathToAttach = pathToAttachment;
            
            mail.Attachments.Add(new Attachment(pathToAttach));
            mail.To.Add(new MailAddress(this._emailSettings.MainTo));
            mail.CC.Add(new MailAddress(this._emailSettings.CopyTo));

            var finalMessage = MimeMessage.CreateFromMailMessage(mail);

            return finalMessage;
        }

        /// <summary>
        /// Метод заменяет особые символы кодировки в сообщении, сохраняя его читабельный формат
        /// </summary>
        private Message ClearIncorrectSymbolsInMessage(MimeMessage messageToReplace)
        {
            
            var dirtyMessage = messageToReplace;
            var clearMessage = new Message();

            using ( var stream = new MemoryStream() )
            {
                dirtyMessage.WriteTo(stream);

                var buffer = stream.ToArray();
                var base64 = Convert.ToBase64String(buffer)
                    .Replace('+', '-')
                    .Replace('/', '_')
                    .Replace("=", "");

                clearMessage.Raw = base64;
            }

            return clearMessage;
        }

        #endregion

    }
}