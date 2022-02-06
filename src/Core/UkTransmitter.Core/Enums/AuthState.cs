namespace UkTransmitter.Core.Enums
{

    /// <summary>
    /// Состояние авторизации пользователя в приложении
    /// </summary>
    public enum AuthState
    {

        /// <summary>
        /// Еще не проходил проверку
        /// </summary>
        NotVerifiedState = 0,

        /// <summary>
        /// Не авторизован
        /// </summary>
        NotAuthorizedState = 1,

        /// <summary>
        /// Авторизован
        /// </summary>
        AuthorizedState = 2,

    }

}