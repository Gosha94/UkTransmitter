namespace UkTransmitter.Core.CommonModels
{

    /// <summary>
    /// Модель данных, вводимая пользователем при входе в приложние
    /// </summary>
    public sealed class InputUserAuthModel
    {

        /// <summary>
        /// 
        /// Вводимый пользователем Логин
        /// </summary>
        public string InsertedLogin { get; set; }

        /// <summary>
        /// Вводимый пользователем Пароль
        /// </summary>
        public string InsertedPwd { get; set; }

    }
}