using UkTransmitter.Core.Contracts.Services;
using UkTransmitter.Domain.Contracts;

namespace UkTransmitter.Domain.Workflows
{

    /// <summary>
    /// Рабочий процесс Авторизация пользователя
    /// </summary>
    internal class UserAuthorizationWorkflow : IBusinessWorkflow
    {

        private readonly ILogService _logService;
        private readonly IAuthService _authService;

        public UserAuthorizationWorkflow(IAuthService authService, ILogService logger)
        {

        }

        public void StartWorkflow()
        {
            _logService.WriteIntoLogAsync($"Наличие пользователя с логином: {this._inputUserData.InsertedLogin} в БД: {isUserCorrect} ");
        }

        public void StopWorkflow()
        {
            throw new System.NotImplementedException();
        }

    }
}