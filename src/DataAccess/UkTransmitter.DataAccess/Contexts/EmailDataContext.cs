using System.Data.Entity;
using UkTransmitter.Core.CommonModels;

namespace UkTransmitter.DataAccess.Contexts
{
    public class EmailDataContext : DbContext
    {
        public EmailDataContext(string connectionString)
            : base(connectionString)
        { }

        /// <summary>
        /// Строки с данными Email ящиков для отправки писем
        /// </summary>
        public DbSet<ReadableEmailModel> EmailDataRows { get; set; }

    }
}
