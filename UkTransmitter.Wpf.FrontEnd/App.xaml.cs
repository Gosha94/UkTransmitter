using System.Windows;
using UkTransmitter.DIContainer.Configuration;
using UkTransmitter.Infrastructure.ModuleContracts;
using UkTransmitter.Wpf.FrontEnd.ApplicationPages.Main;

namespace UkTransmitter.Wpf.FrontEnd
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var diFabric = new DependencyFabric();
            //diFabric.RegisterAllScopesInApp();

            //IAuthService authServ = diFabric.GetAuthService();
            //authServ.GoAuth();

            var mainPage = new MainWindow();
            var dataContext = new MainWindowViewModel();
            mainPage.DataContext = dataContext;
            mainPage.Show();

        }
    }
}
