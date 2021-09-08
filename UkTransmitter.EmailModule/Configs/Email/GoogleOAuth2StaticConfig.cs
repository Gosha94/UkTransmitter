namespace UkTransmitter.BackEnd.Configs.Email
{
    internal static class GoogleOAuth2StaticConfig
    {
        public static string ClientInfo { get; private set; } = @"D:\GmailAPI\ClientCredentials\client_secret.json";
        public static string CredentialsInfo { get; private set; } = @"D:\GmailAPI\CredentialsInfo\";
        public static string ApplicationName { get; private set; } = "GmailApi";
    }
}
