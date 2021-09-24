using System.Data.Entity;
using UkTransmitter.Core.CommonModels;

namespace UkTransmitter.DataAccess.Contexts
{
    public class MeteringDataContext : DbContext
    {
        /// <summary>
        /// Контекст-подключение к БД, связано с подключением в App.config
        /// </summary>
        public MeteringDataContext() : base(@"data source=.\SQLSERVER;Initial Catalog=UkSender; Integrated Security = True;")
        { }

        /// <summary>
        /// Набор данных-модель для записи показаний в БД
        /// </summary>
        public DbSet<MeteringDataModel> MeteringData { get; set; }

        /// <summary>
        /// Модель для строки подключения БД, отличных от MS SQL Server
        /// </summary>
        public DbSet<ConnectionStringModel> ConnectionString { get; set; }

        /// <summary>
        /// Модель данных авторизации пользователя
        /// </summary>
        public DbSet<UserAuthorizeModel> UsersAuthorizeData { get; set; }
        
        /// <summary>
        /// Модель данных для отправки письма
        /// </summary>
        public DbSet<EmailModel> EmailData { get; set; }

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
