using UkTransmitter.Core.Enums;

namespace UkTransmitter.Core.CommonModels.DTOs
{
    public class UserUnderAuthDTO
    {
        public string UserName { get; set; }

        public AuthState AuthState { get; set; }
    }
}