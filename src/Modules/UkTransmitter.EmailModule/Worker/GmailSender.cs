using System;
using System.IO;
using System.Net.Mail;
using System.Threading;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using UkTransmitter.BackEnd.Configs.Email;

namespace UkSender.EmailAPI.Controllers
{

    /// <summary>
    /// Класс описывает Отправлятор Писем при помощи Gmail API
    /// </summary>
    internal sealed class GmailSender
    {

        

        public GmailService GetService()
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
            return service;
        }

        public static MimeKit.MimeMessage CreateMimeMessage()
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

            var finalMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);

            return finalMessage;
        }


        private Action _sendEmailAction;
        private EmailService _gmailApiService;

        public GmailSender()
        {
            _gmailApiService = GmailController.GetService();
            _sendEmailAction = SendMessageAction;
        }

        public void SendMessageAsync()
        {
            Task.Run(_sendEmailAction);
        }

        private void SendMessageAction()
        {
            Message message = new Message();
            var tempMail = GmailController.CreateMimeMessage();

            using (var stream = new MemoryStream())
            {
                tempMail.WriteTo(stream);

                var buffer = stream.ToArray();
                var base64 = Convert.ToBase64String(buffer)
                    .Replace('+', '-')
                    .Replace('/', '_')
                    .Replace("=", "");

                message.Raw = base64;
            }

            _gmailApiService.Users.Messages.Send(message, GmailStaticConfiguration.HostAddress).Execute();
        }

    }
}