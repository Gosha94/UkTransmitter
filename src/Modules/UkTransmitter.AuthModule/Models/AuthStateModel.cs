namespace UkTransmitter.AuthModule.StateModels
{

    /// <summary>
    /// Структура отражает текущее состояние авторизации пользователя
    /// </summary>
    public struct AuthStateModel
    {
        
        public readonly int UserId;
        public readonly bool IsAuthSucceed;


        public AuthStateModel(int userId, bool isRightAuth)
        {
            this.UserId = userId;
            this.IsAuthSucceed = isRightAuth;
        }

    }

}