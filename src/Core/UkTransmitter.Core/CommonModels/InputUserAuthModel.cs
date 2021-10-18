namespace UkTransmitter.Core.CommonModels
{

    /// <summary>
    /// Модель данных, вводимая пользователем при входе в приложние
    /// </summary>
    public sealed class InputUserAuthModel
    {        
        public string InsertedLogin { get; set; }
        public string InsertedPwd { get; set; }

        public bool IsAuthSucceed { get; set; }
    }
}