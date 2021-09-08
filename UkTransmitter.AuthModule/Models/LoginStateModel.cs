namespace UkSender.CommonLibrary.StateModels
{
    /// <summary>
    /// Класс отражает текущее состояние авторизации пользователя
    /// </summary>
    internal sealed class LoginStateModel
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LoginStateModel()
        {
            this.IsCurrentUserRight = false;
        }

        private bool _isCurrentUserRight;

        public bool IsCurrentUserRight
        {
            get => _isCurrentUserRight;
            set { _isCurrentUserRight = value; }
        }
    }
}
