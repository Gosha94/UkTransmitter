namespace UkTransmitter.Core.CommonModels.JsonConfigurationModels
{
    public class ConnectionData
    {
        public int Id { get; set; }
        public string Server { get; set; }
        public string ConnectionString { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class Root
    {
        public ConnectionData ConnectionData { get; set; }
    }
}
