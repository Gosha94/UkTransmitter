namespace UkTransmitter.AuthModule.StateModels
{
    /// <summary>
    /// Класс отражает текущее состояние авторизации пользователя
    /// </summary>
    internal sealed class LoginStateModel
    {

        private bool _isCurrentUserRight;

        public bool IsCurrentUserRight
        {
            get => _isCurrentUserRight;
            set { _isCurrentUserRight = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LoginStateModel()
        {
            this.IsCurrentUserRight = false;
        }
    }
}
