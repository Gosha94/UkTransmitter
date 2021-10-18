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
        /// Модель для записи показаний в БД
        /// </summary>
        public DbSet<WriteableMeteringDataModel> MeteringData { get; set; }

        /// <summary>
        /// Модель данных авторизации пользователя
        /// </summary>
        public DbSet<ReadableUserAuthorizeModel> UsersAuthorizeData { get; set; }
        
        /// <summary>
        /// Модель данных для отправки письма
        /// </summary>
        public DbSet<ReadableEmailModel> EmailData { get; set; }

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
