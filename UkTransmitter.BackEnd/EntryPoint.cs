using System;
using UkTransmitter.DIContainer.Configuration;
using UkTransmitter.Infrastructure.ModuleContracts;

namespace UkTransmitter.BackEnd
{
    static class EntryPoint
    {
        static void Main()
        {
            var diFabric = new DependencyFabric();
            diFabric.RegisterAllScopesInApp();

            IAuthService authServ = diFabric.GetAuthService();
            authServ.GoAuth();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}