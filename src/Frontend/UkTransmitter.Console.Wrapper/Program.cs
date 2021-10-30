using UkTransmitter.Core.Contracts;
using UkTransmitter.DataAccess.Repos;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.AuthModule.Service;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.LogModule.Service;
using System.Threading.Tasks;

namespace UkTransmitter.Console.Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Dependency Injection

            // D:\Projects\_NET\WPF\UkTransmitter\src\Frontend\UkTransmitter.Console.Wrapper\bin\Debug\UkTransmitterLogs.txt
            ILogService testLogger = new CustomNLogService();
            IReadOnlyRepository<InputUserAuthModel> repos = new UserAuthRepository();
            InputUserAuthModel inputTestModel = new InputUserAuthModel()
            {
                InsertedLogin = "Gosha",
                InsertedPwd = "1111"
            };

            IAuthService customAuthService = new AuthService(repos, inputTestModel, testLogger);

            #endregion

            #region Test Auth Service

            AsyncCheckAuthService(customAuthService);

            #endregion

            #region Test File Service



            #endregion

            #region Test Log Service

            AsyncCheckLogService(testLogger);

            #endregion

            #region Test Email Service



            #endregion

            var input = System.Console.ReadLine();

            System.Console.ReadLine();

        }

        private static async void AsyncCheckAuthService(IAuthService authService)
        {
            var isUserExist = await authService.IsUserCorrectAsync();

            if (isUserExist)
            {
                System.Console.WriteLine("Auth Service Working Correct! Access Granted!");
            }
        }

        private static async void AsyncCheckFileService(IFileService fileService)
        {
            
        }

        private static async void AsyncCheckLogService(ILogService logService)
        {
            await Task.Run(() =>
            {
                logService.WriteIntoLogAsync("This is test logged message from Wrapper!!!");
                System.Console.WriteLine("Log Service Working Correct!");
            });
        }

        private static async void AsyncCheckEmailService(IEmailService emailService)
        {

        }

    }
}
