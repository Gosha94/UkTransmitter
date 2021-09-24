using System;

namespace UkTransmitter.Core.CommonModels
{
    public class DataForUkModel
    {
        public string MeteringDevice { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
        public string EmailedStatus { get; set; }
    }
}
