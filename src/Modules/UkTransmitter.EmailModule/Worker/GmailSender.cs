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
using UkTransmitter.BackEnd.Configs.Email;
using UkTransmitter.EmailModule.Contracts;

namespace UkTransmitter.EmailModule.Worker
{

    /// <summary>
    /// Класс описывает Отправлятор Писем при помощи Gmail API
    /// </summary>
    internal sealed class GmailSender : IEmailSender
    {

        #region Private Fields

        private GmailService _gmailService;

        #endregion

        #region Public Properties

        #endregion

        #region Constructor
        
        public GmailSender()
        {
            InitializeGmailService();
        }

        #endregion

        #region Public API

        public bool SendEmailMessage()
        {

            var tempMessage = CreateMimeMessage();
            var readyToSendMessage = ClearIncorrectSymbolsInMessage(tempMessage);

            _gmailApiService.Users.Messages.Send(message, GmailStaticConfiguration.HostAddress).Execute();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод инициализирует службу Google Mail
        /// </summary>
        private void InitializeGmailService()
        {
            UserCredential credential;
            using (
                FileStream stream = new FileStream(
                    GoogleOAuth2Configuration.ClientInfo,
                    FileMode.Open,
                    FileAccess.Read
                    )
                )
            {
                String FolderPath = GoogleOAuth2Configuration.CredentialsInfo;
                String FilePath = Path.Combine(FolderPath, "APITokenCredentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    GoogleOAuth2Configuration.Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(FilePath, true)).Result;
            }
            // Create Gmail API service.
            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = GmailStaticConfiguration.ApplicationName,
            });

            this._gmailService = service;
        }

        /// <summary>
        /// Метод подготовки текста сообщения
        /// </summary>
        /// <returns>Закодированное сообщение со спец. символами</returns>
        private MimeMessage CreateMimeMessage()
        {
            MailMessage mail = new MailMessage();
            mail.Subject = GmailMessageModel.Subject;
            mail.From = new MailAddress(GmailMessageModel.From);
            mail.BodyEncoding = Encoding.UTF8;
            mail.Body = GmailMessageModel.Body;
            mail.IsBodyHtml = true;
            string attImg = GmailStaticConfiguration.GmailAttach + "JonWick.jpg";

            mail.Attachments.Add(new Attachment(attImg));
            mail.To.Add(new MailAddress(GmailMessageModel.To));
            mail.CC.Add(new MailAddress(GmailMessageModel.СС));

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