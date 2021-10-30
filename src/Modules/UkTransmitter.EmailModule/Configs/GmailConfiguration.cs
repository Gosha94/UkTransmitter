using UkTransmitter.EmailModule.Contracts;

namespace UkTransmitter.EmailModule.Configs
{

    /// <summary>
    /// Конфигурация для работы с почтой Gmail
    /// </summary>
    internal sealed class GmailConfiguration : IEmailConfiguration
    {
        public string PathToJsonSettingsFile { get; private set; } = @"D:\UkTransmitterConfig\EmailSettings\UserSettings\CustomEmailSettings.json";
    }
}