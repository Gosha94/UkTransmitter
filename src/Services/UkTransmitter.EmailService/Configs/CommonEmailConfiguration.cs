using UkTransmitter.EmailService.Contracts;

namespace UkTransmitter.EmailService.Configs
{

    /// <summary>
    /// Конфигурация c общими данными для отправки письма в УК
    /// </summary>
    internal sealed class CommonEmailConfiguration : IEmailSettings
    {
        public string PathToJsonEmailSettingsFile { get; private set; } = @"D:\UkTransmitterConfig\EmailSettings\UserSettings\CommonEmailSettings.json";
    }
}