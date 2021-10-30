using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.DataAccess.Repos;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.LogModule.Service;
using UkTransmitter.FileModule.Config;
using UkTransmitter.AuthModule.Service;
using UkTransmitter.FileModule.Service;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.Console.Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Dependency Injection

            // D:\Projects\_NET\WPF\UkTransmitter\src\Frontend\UkTransmitter.Console.Wrapper\bin\Debug\UkTransmitterLogs.txt
            ILogService testLogService = new CustomNLogService();
            IReadOnlyRepository<InputUserAuthModel> repos = new UserAuthRepository();
            InputUserAuthModel inputTestModel = new InputUserAuthModel()
            {
                InsertedLogin = "Gosha",
                InsertedPwd = "1111"
            };

            IAuthService customAuthService = new AuthService(repos, inputTestModel, testLogService);

            IAttachmentConfiguration attachmentConfig = new AttachmentConfiguration();
            ITemplateConfiguration templateConfig = new TemplateConfiguration();

            IFileService testFileService =
                new FileService
                (
                    attachmentConfig,
                    templateConfig,
                    testLogService
                );

            #endregion

            #region Test Auth Service

            AsyncCheckAuthServiceStub(customAuthService);

            #endregion

            #region Test File Service

            AsyncCheckFileServiceStub(testFileService);

            #endregion

            #region Test Log Service

            AsyncCheckLogServiceStub(testLogService);

            #endregion

            #region Test Email Service



            #endregion

            var input = System.Console.ReadLine();

            System.Console.ReadLine();

        }

        private static async void AsyncCheckAuthServiceStub(IAuthService authService)
        {
            var isUserExist = await authService.IsUserCorrectAsync();

            if (isUserExist)
            {
                System.Console.WriteLine("Auth Service Working Correct! Access Granted!");
            }
            else
            {
                System.Console.WriteLine("Auth Service Working Correct! Access Denied! User Incorrect!");
            }

        }

        private static async void AsyncCheckFileServiceStub(IFileService fileService)
        {
            var isAttachmentWasCreated = await fileService.CreateAttachmentAsync();
            
            if (isAttachmentWasCreated)
            {
                System.Console.WriteLine("File Service Working Correct! Attachment Was Created!");
            }
            else
            {
                System.Console.WriteLine("Auth Service is Broken! Error occured! Attachment not creted!");
            }
        }

        private static async void AsyncCheckLogServiceStub(ILogService logService)
        {
            await Task.Run(() =>
            {
                logService.WriteIntoLogAsync("This is test logged message from Wrapper!!!");
                System.Console.WriteLine("Log Service Working Correct!");
            });
        }

        private static async void AsyncCheckEmailServiceStub(IEmailService emailService)
        {

        }

    }
}
