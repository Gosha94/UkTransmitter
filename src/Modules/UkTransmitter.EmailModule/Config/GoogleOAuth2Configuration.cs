namespace UkTransmitter.BackEnd.Configs.Email
{
    internal sealed class GoogleOAuth2Configuration
    {
        public readonly string ClientInfo = @"D:\GmailAPI\ClientCredentials\client_secret.json";
        public static string CredentialsInfo { get; private set; } = @"D:\GmailAPI\CredentialsInfo\";
        public static string ApplicationName { get; private set; } = "GmailApi";
    }
}
