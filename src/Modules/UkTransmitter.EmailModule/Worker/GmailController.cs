namespace UkSender.EmailAPI.Controllers
{
    internal sealed class GmailController
    {
        public static GmailService GetService()
        {
            UserCredential credential;
            using (
                FileStream stream = new FileStream(
                    GmailStaticConfiguration.ClientInfo,
                    FileMode.Open,
                    FileAccess.Read
                    )
                )
            {
                String FolderPath = GmailStaticConfiguration.CredentialsInfo;
                String FilePath = Path.Combine(FolderPath, "APITokenCredentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    GmailStaticConfiguration.Scopes,
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
    }
}