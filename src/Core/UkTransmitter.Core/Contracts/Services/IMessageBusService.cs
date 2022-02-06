using System.Threading.Tasks;

namespace UkTransmitter.Core.Contracts.Services
{
    public interface IMessageBusService
    {
        Task Publish();
        Task Consume();
    }
}