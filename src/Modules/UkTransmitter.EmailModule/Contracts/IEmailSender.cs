namespace UkTransmitter.EmailModule.Contracts
{

    /// <summary>
    /// Интерфейс описывает Отправлятор писем
    /// </summary>
    public interface IEmailSender
    {

        /// <summary>
        /// Метод отправки сообщения
        /// </summary>
        /// <returns>Успех отправки</returns>
        bool SendEmailMessage();
        
    }
}
