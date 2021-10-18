using System.Data.Entity;
using UkTransmitter.Core.CommonModels;

namespace UkTransmitter.DataAccess.Contexts
{
    public class MeteringDataContext : DbContext
    {

        public MeteringDataContext(string connectionString) 
            : base(connectionString)
        { }

        /// <summary>
        /// Строки с показаниями счетчиков в БД
        /// </summary>
        public DbSet<WriteableMeteringDataModel> MeteringDataRows { get; set; }

        /// <summary>
        /// Метод очистки миграций
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MeteringDataContext>(null);
            base.OnModelCreating(modelBuilder);
        }

    }
}