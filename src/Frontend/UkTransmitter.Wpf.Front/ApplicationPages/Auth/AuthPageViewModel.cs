using System.Windows.Input;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.DIContainer.Configuration;
using UkTransmitter.Wpf.FrontEnd.Infrastructure;

namespace UkTransmitter.Wpf.FrontEnd.ApplicationPages.Auth
{
    /// <summary>
    /// Модель представления для Аутентификации
    /// </summary>
    internal sealed class AuthPageViewModel : BaseViewModel, ICustomViewModel
    {

        private readonly IAuthService   _authService;
        private readonly ILogService    _logService;

        public AuthPageViewModel(DependencyFabric _dependencyFabric)
        {
            _authService =  _dependencyFabric.GetAuthService();
            _logService  =  _dependencyFabric.GetLogService();
        }

        private void CallAuthService()
        {
            _authService.SendCall();
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
