using System;
using System.Threading.Tasks;
using UkTransmitter.Core.Enums;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Domain.Contracts;
using UkTransmitter.Core.CommonModels.DTOs;
using UkTransmitter.Core.Contracts.Services;
using System.Text;
using Newtonsoft.Json;

namespace UkTransmitter.Domain.Workflows
{

    /// <summary>
    /// Рабочий процесс Авторизация пользователя
    /// </summary>
    internal class UserAuthorizationWorkflow : IBusinessWorkflow
    {

        private readonly ILogService _logService;
        private readonly IAuthService _authService;
        private readonly IMessageBusClient _messageBusClient;

        public UserAuthorizationWorkflow(IAuthService authServiceFromDi, ILogService logServiceFromDi, IMessageBusClient busClientFromDi)
        {
            _logService = logServiceFromDi;
            _authService = authServiceFromDi;
            _messageBusClient = busClientFromDi;
        }

        public async Task StartWorkflow()
        {

            var userDto = DeserializeUserDataFromMessageBus(_messageBusClient.Consume("AuthExchange"));
            
            if (userDto == null)
            {
                _logService.WriteLogAsync($"ERROR_{DateTime.Now}_incorrect auth user data consume from MessageBus");
            }

            if (!_authService.TryAuthentificate(userDto))
            {
                _logService.WriteLogAsync($"ERROR_{DateTime.Now}_incorrect name or pass - {userDto.UserName}, Authentificate Failed!");
            }

            _messageBusClient.Publish("SuccessAuth", SerializeUserDataForMessageBus(userDto));

        }

        public async Task StopWorkflow()
        {
            _logService.WriteLogAsync($"INFO_{DateTime.Now}_UserAuthWorkflow Stopped!");
        }

        public UserUnderAuthDTO DeserializeUserDataFromMessageBus(byte[] userDataArray) => JsonConvert.DeserializeObject<UserUnderAuthDTO>(Encoding.UTF8.GetString(userDataArray));
        public byte[] SerializeUserDataForMessageBus(UserUnderAuthDTO userDto) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userDto));

    }
}