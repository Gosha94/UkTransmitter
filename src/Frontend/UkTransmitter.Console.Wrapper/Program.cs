using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UkTransmitter.Core.Contracts;
using UkTransmitter.DataAccess.Repos;
using UkTransmitter.Core.CommonModels.DTOs;
using UkTransmitter.Core.Contracts.Services;

namespace UkTransmitter.Console.Wrapper
{
    class Program
    {

        private static List<Task> _taskList;
        private static string _attachmentPath;
        private static bool _isUserCorrect;

        static void Main(string[] args)
        {
        //    _taskList = new List<Task>();
        //    _attachmentPath = String.Empty;           

        //    // D:\Projects\_NET\WPF\UkTransmitter\src\Frontend\UkTransmitter.Console.Wrapper\bin\Debug\UkTransmitterLogs.txt
        //    ILogService testLogService = new CustomNLogService();

        //    IEmailService testEmailService = new EmailService(testLogService);

        //    #region UserInput

        //    InputUserAuthModel inputTestModelFromUser = new InputUserAuthModel();
        //    System.Console.WriteLine("Добро пожаловать в приложение UkTransmitter!");
        //    System.Console.WriteLine("Введите имя пользователя:");
        //    inputTestModelFromUser.InsertedLogin = System.Console.ReadLine();
        //    System.Console.WriteLine("Введите пароль:");
        //    inputTestModelFromUser.InsertedPwd = System.Console.ReadLine();

        //    #endregion

        //    #region Auth Service

        //    IUsersRepository<InputUserAuthModel> testRepos = new UserAuthRepository();
        //    IAuthService customAuthService = new AuthService(testRepos, inputTestModelFromUser, testLogService);
        //    AsyncCheckAuthServiceStub(customAuthService);

        //    #endregion

        //    if (_isUserCorrect)
        //    {

        //        #region File Service

        //        IAttachmentConfiguration testAttachmentConfig = new AttachmentConfiguration();
        //        ITemplateConfiguration testTemplateConfig = new TemplateConfiguration();
                
        //        List<string> inputMeteringDataFromUser = new List<string>();

        //        System.Console.ForegroundColor = ConsoleColor.Gray;

        //        System.Console.WriteLine("Хол. вода:");
        //        inputMeteringDataFromUser.Add(System.Console.ReadLine());                
        //        System.Console.WriteLine("Гор. вода:");
        //        inputMeteringDataFromUser.Add(System.Console.ReadLine());
        //        System.Console.WriteLine("Отопление:");
        //        inputMeteringDataFromUser.Add(System.Console.ReadLine());
        //        System.Console.WriteLine("Эл-во:");
        //        inputMeteringDataFromUser.Add(System.Console.ReadLine());

        //        IDtoForFillAttachment testAttachmentData = new DataForFillTemplateDto()
        //        {
        //            PathToNewAttachmentFile = testAttachmentConfig.PathToAttachmentsCatalog,
        //            ReceivedFromUserMeteringDataArray = inputMeteringDataFromUser.ToArray(),
        //        };

        //        IFileService testFileService =
        //            new FileService
        //            (
        //                testAttachmentConfig,
        //                testTemplateConfig,
        //                testAttachmentData,
        //                testLogService
        //            );

        //        AsyncCheckFileServiceStub(testFileService);

        //        #endregion

        //        #region Email Service

        //        //AsyncCheckEmailServiceStub(testEmailService);

        //        #endregion
        //    }

        //    System.Console.ForegroundColor = ConsoleColor.Gray;
        //    System.Console.WriteLine("Для выхода из приложения нажмите Enter...");
        //    System.Console.ReadLine();

        }


        private static async void AsyncCheckAuthServiceStub(IAuthService authService)
        {

            _isUserCorrect = authService.TryAuthentificate(new UserUnderAuthDTO());

            if (_isUserCorrect)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Async Access Granted from Auth Service!");
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Async Access Denied from Auth Service! User Incorrect!");
            }

        }

        private static async void AsyncCheckLogServiceStub(ILogService logService)
        {
            await Task.Run(() =>
            {
                logService.WriteLogAsync("This is test logged message from Wrapper!!!");
                System.Console.WriteLine("Log Service Working Correct!");
            });
        }

        private static void AsyncCheckFileServiceStub(IFileService fileService)
        {
           _taskList.Add(Task.Run(
                async () =>
               {
                   var attachmentPath = await fileService.CreateAttachmentAsync();

                   if (!String.IsNullOrEmpty(attachmentPath))
                   {
                       System.Console.ForegroundColor = ConsoleColor.Green;
                       System.Console.WriteLine($"File Service Working Correct! Attachment Was Created! \n Path: {attachmentPath}");
                   }
                   else
                   {
                       System.Console.ForegroundColor = ConsoleColor.Red;
                       System.Console.WriteLine("File Service is Broken! Error occured! Attachment not created!");
                   }

                   _attachmentPath = attachmentPath;

               })
            );
        }

        // TODO: Почтовая Служба должна проверить: была ли отправка в этом месяце, если была, оповестить и не отправлять более писем!!!
        private static async void AsyncCheckEmailServiceStub(IEmailService emailService)
        {
            var finalTask = Task.WhenAll(_taskList);

            finalTask.Wait();

            if (finalTask.Status == TaskStatus.RanToCompletion)
            {
                var isEmailWasSended = await emailService.SendEmailAsync(_attachmentPath);

                if (isEmailWasSended)
                {
                    System.Console.WriteLine("Email Service Working Correct! Email Was Sended!");
                }
                else
                {
                    System.Console.WriteLine("Email Service is Broken! Error occured! Email not Sended!");
                }
            }
        }

    }
}