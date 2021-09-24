namespace UkTransmitter.Infrastructure.ModuleContracts
{
    /// <summary>
    /// Интерфейс службы аутентификации для изоляции сторонних библиотек
    /// </summary>
    public interface IAuthService
    {
        void GoAuth();

        void SendCall();
    }
}
