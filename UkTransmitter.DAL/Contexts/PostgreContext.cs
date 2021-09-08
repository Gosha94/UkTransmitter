using System.Data.Entity;

namespace UkSender.DAL
{
    public class PostgreContext : DbContext
    {
        private const string _schema = "UkSender";

        public PostgreContext(string connectionString)
          : base(connectionString)
        { }
        
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(_schema);
            base.OnModelCreating(builder);
        }
    }
}
