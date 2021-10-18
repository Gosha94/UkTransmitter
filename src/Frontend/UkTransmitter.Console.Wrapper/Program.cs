using UkTransmitter.Core.Contracts;
using UkTransmitter.DataAccess.Repos;
using UkTransmitter.Core.CommonModels;
using UkTransmitter.AuthModule.Service;

namespace UkTransmitter.Console.Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadOnlyRepository<InputUserAuthModel> repos = new UserAuthRepository();
            
            InputUserAuthModel inputTestModel = new InputUserAuthModel()
            {
                InsertedLogin = "Gosha",
                InsertedPwd = "1111"
            };

            AuthService customAuthService = new AuthService(repos, inputTestModel);
            var res = customAuthService.IsUserCorrect();
            System.Console.WriteLine();
        }
    }
}
