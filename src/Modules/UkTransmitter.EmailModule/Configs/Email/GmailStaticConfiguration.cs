namespace UkTransmitter.BackEnd.Configs.Email
{
    /// <summary>
    /// Конфигурация почтовой службы
    /// </summary>
    internal static class GmailStaticConfiguration
    {
        public static string HostAddress { get; private set; } = @" my email address";
        public static string GmailAttach { get; private set; } = @"D:\GmailAPI\GmailAttachments\";
        //public static string[] Scopes { get; private set; } = { GmailService.Scope.MailGoogleCom };
    }
}
