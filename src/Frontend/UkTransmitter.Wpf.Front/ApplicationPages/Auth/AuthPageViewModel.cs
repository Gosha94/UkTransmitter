using System.Windows.Input;
using UkTransmitter.Core.Contracts.Services;
using UkTransmitter.DIContainer.Configuration;
using UkTransmitter.Wpf.FrontEnd.Infrastructure;

namespace UkTransmitter.Wpf.FrontEnd.ApplicationPages.Auth
{
    /// <summary>
    /// Модель представления для Аутентификации
    /// </summary>
    internal sealed class AuthPageViewModel : BaseViewModel, ICustomViewModel
    {

        private readonly ILogService _logService;
        private readonly IAuthService _authService;

        public AuthPageViewModel()
        {
            //_authService = authServFromDi;
            //_logService = logServFromDi;
        }

        private void CallAuthService()
        {
            //_authService.SendCall();
        }

        public string Title { get => "AuthPage"; }

        public ICommand LogInCommand
        {
            get
                => new RelayCommand
                    (
                        executingObj =>
                        {
                            CallAuthService();
                        },
                        canExec => true
                    );
        }

        public string AuthMessage { get; set; }

        public bool AuthStatus { get; set; }

        public bool IsAuthMessageReceived { get; set; }

    }
}
