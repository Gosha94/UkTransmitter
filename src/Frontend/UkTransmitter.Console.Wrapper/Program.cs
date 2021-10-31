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

using System.Net;
using System.Collections.Specialized;
using System.Text;
using System;

using System.Web;

namespace UkTransmitter.Console.Wrapper
{
    class Program
    {

        private static List<Task> _taskList;

        static void Main(string[] args)
        {
            _taskList = new List<Task>();

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

            //IEmailService testEmailService = new EmailService(testAttachmentData, testLogService);

            #endregion

            try
            {
                #region Elastic Email Test
                
                //NameValueCollection values = new NameValueCollection();
                //values.Add("apikey", "3BC0FD1E8FE08A5973889A9F10D4E463B398FBE99B1B22E2308E37A7C572DCD552ACB5EAA49A3AF6ACD0B50A21ED07C6");
                //values.Add("from", "igeorg70@gmail.com");
                //values.Add("fromName", "Your Company Name");
                //values.Add("to", "gerizch@rambler.ru");
                //values.Add("to", "igeorg70@gmail.com");
                //values.Add("subject", "Your Subject");
                //values.Add("bodyText", "Text Body");
                //values.Add("bodyHtml", "<h1>Html Body</h1>");
                //values.Add("isTransactional", "true");
                
                //string address = "https://api.elasticemail.com/v2/email/send";

                //string response = SyncronSendThrougthWebClient(address, values);

                //System.Console.WriteLine(response);
                System.Console.WriteLine();
                #endregion

                #region Test Auth Service

                //AsyncCheckAuthServiceStub(customAuthService);

                #endregion

                #region Test File Service

                //TaskCheckFileServiceStub(testFileService);

                #endregion

                #region Test Log Service

                //AsyncCheckLogServiceStub(testLogService);

                #endregion

                #region Test Email Service

                //AsyncCheckEmailServiceStub(testEmailService);

                #endregion

                var input = System.Console.ReadLine();

            }
            catch (System.Exception ex)
            {
                testLogService.WriteIntoLog(ex.Message);
            }

        }


        private static string SyncronSendThrougthWebClient(string address, NameValueCollection values)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] apiResponse = client.UploadValues(address, values);
                    return Encoding.UTF8.GetString(apiResponse);

                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }

        private static async Task AsyncSendThrougthHttpClient(string address, NameValueCollection values)
        {


            var apiUri = "https://api.elasticemail.com/v2/email/send";
            var uriBuilder = new UriBuilder(apiUri);
            var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);

            queryString.Add("apikey", "3BC0FD1E8FE08A5973889A9F10D4E463B398FBE99B1B22E2308E37A7C572DCD552ACB5EAA49A3AF6ACD0B50A21ED07C6");
            queryString.Add("from", "igeorg70@gmail.com");
            queryString.Add("fromName", "Your Company Name");
            queryString.Add("to", "gerizch@rambler.ru");
            queryString.Add("subject", "Your Subject");
            queryString.Add("bodyText", "Text Body");
            queryString.Add("bodyHtml", "<h1>Html Body</h1>");
            queryString.Add("isTransactional", "true");

            //var filepath = "C:\\example\\helloWorld.txt";
            //var file = File.OpenRead(filepath);

            //var filesStream = new Stream[] { file };
            //var filenames = new string[] { "filenameForInbox.txt" };

            uriBuilder.Query = queryString.ToString();
            apiUri = uriBuilder.ToString();


            //using (var asyncClient = new HttpClient())
            //{
            //    HttpContent c = new HttpContent().;
            //    var result = await asyncClient.PostAsync()
            //}
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

        private static void TaskCheckFileServiceStub(IFileService fileService)
        {
            _taskList.Add(
               Task.Run(
                  async () =>
                  {
                      var isAttachmentWasCreated = await fileService.CreateAttachmentAsync();

                      if (isAttachmentWasCreated)
                      {
                          System.Console.WriteLine("File Service Working Correct! Attachment Was Created!");
                      }
                      else
                      {
                          System.Console.WriteLine("File Service is Broken! Error occured! Attachment not created!");
                      }
                  })
               );
        }

        private static async void AsyncCheckEmailServiceStub(IEmailService emailService)
        {
            var finalTask = Task.WhenAll(_taskList);

            finalTask.Wait();

            if (finalTask.Status == TaskStatus.RanToCompletion)
            {
                var isEmailWasSended = await emailService.SendEmailAsync();

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