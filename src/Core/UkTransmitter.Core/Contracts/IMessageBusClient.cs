namespace UkTransmitter.Core.Contracts
{
    public interface IMessageBusClient
    {
        void Publish(string exchangeName, byte[] data);

        byte[] Consume(string exchangeName);
    }
}