using Google.Apis.Gmail.v1;

namespace UkTransmitter.BackEnd.Configs.Email
{
    internal static class GoogleOAuth2Configuration
    {
        public readonly static string ClientInfo = @"D:\UkTransmitterConfig\EmailSettings\GmailAPI\ClientCredentials\client_secret.json";
        public readonly static string CredentialsInfo = @"D:\UkTransmitterConfig\EmailSettings\GmailAPI\CredentialsInfo\";
        public readonly static string ApplicationName = "GmailApi";
        public readonly static string[] Scopes = { GmailService.Scope.MailGoogleCom };
    }
}
