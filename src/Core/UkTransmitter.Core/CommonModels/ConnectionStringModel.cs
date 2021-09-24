﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UkTransmitter.Core.CommonModels
{
    [Table("connect.tConnectionString")]
    public class ConnectionStringModel
    {
        [Key]
        public int Id { get; set; }
        public string ConnectionName { get; set; }
        public string ConnectionString { get; set; }
    }
}
