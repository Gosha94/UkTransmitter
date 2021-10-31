using System.Threading.Tasks;

using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.Core.ModuleContracts;

//using UkTransmitter.DataAccess.Repos;

using UkTransmitter.FileModule.Config;
using UkTransmitter.FileModule.Service;

using UkTransmitter.LogModule.Service;
using UkTransmitter.Core.CommonModels.DTOs;
using System.Collections.Generic;
using UkTransmitter.EmailModule.Service;
using System;
using UkTransmitter.AuthModule.Service;
using UkTransmitter.DataAccess.Repos;

namespace UkTransmitter.Console.Wrapper
{
    class Program
    {

        private static List<Task> _taskList;
        private static string _attachmentPath;
        static void Main(string[] args)
        {
            _taskList = new List<Task>();
            _attachmentPath = String.Empty;

            #region Dependency Injection

            // D:\Projects\_NET\WPF\UkTransmitter\src\Frontend\UkTransmitter.Console.Wrapper\bin\Debug\UkTransmitterLogs.txt
            ILogService testLogService = new CustomNLogService();
            //IReadOnlyRepository<InputUserAuthModel> repos = new UserAuthRepository();
            InputUserAuthModel inputTestModel = new InputUserAuthModel()
            {
                InsertedLogin = "Gosha",
                InsertedPwd = "1111"
            };

            //IAuthService customAuthService = new AuthService(repos, inputTestModel, testLogService);

            IAttachmentConfiguration testAttachmentConfig = new AttachmentConfiguration();
            ITemplateConfiguration testTemplateConfig = new TemplateConfiguration();
            
            IDtoForFillAttachment testAttachmentData = new DataForFillTemplateDto()
            {
                PathToNewAttachmentFile = testAttachmentConfig.PathToAttachmentsCatalog,
                ReceivedFromUserMeteringDataArray = new string[] { "1_2_3", "4_5_6", "7_8_9", "10_11_12" }
            };

            IFileService testFileService =
                new FileService
                (
                    testAttachmentConfig,
                    testTemplateConfig,
                    testAttachmentData,
                    testLogService
                );

            IEmailService testEmailService = new EmailService(testLogService);

            #endregion

            try
            {
                #region Elastic Email Test


                #endregion

                #region Test Auth Service

                //AsyncCheckAuthServiceStub(customAuthService);

                #endregion

                #region Test File Service

                AsyncCheckFileServiceStub(testFileService);

                #endregion

                #region Test Log Service

                AsyncCheckLogServiceStub(testLogService);

                #endregion

                #region Test Email Service
                
                AsyncCheckEmailServiceStub(testEmailService);

                #endregion

                var input = System.Console.ReadLine();

            }
            catch (System.Exception ex)
            {
                testLogService.WriteIntoLog(ex.Message);
            }

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

        private static async void AsyncCheckLogServiceStub(ILogService logService)
        {
            await Task.Run(() =>
            {
                logService.WriteIntoLogAsync("This is test logged message from Wrapper!!!");
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
                       System.Console.WriteLine($"File Service Working Correct! Attachment Was Created! \n Path: {attachmentPath}");
                   }
                   else
                   {
                       System.Console.WriteLine("File Service is Broken! Error occured! Attachment not created!");
                   }

                   _attachmentPath = attachmentPath;

               })
            );
        }

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