using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UkTransmitter.Core.CommonModels
{
    /// <summary>
    /// Модель счетчика в БД
    /// </summary>
    #if DEBUG
    [Table("dataUk.MeteringData_Test")]
    #endif
    #if !DEBUG
    [Table("dataUk.MeteringData")]
    #endif
    public class WriteableMeteringDataModel
    {
        [Key]
        public int Id { get; set; }

        public int MeteringDeviceType { get; set; }

        public string Value { get; set; }
        
        [Column(TypeName = "datetime2")]        
        public DateTime CombineDtm { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SendDtm { get; set; }
    }
}
