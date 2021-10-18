using System.Data.Entity;
using UkTransmitter.Core.CommonModels;

namespace UkTransmitter.DataAccess.Contexts
{
    public class UserAuthContext : DbContext
    {
        public UserAuthContext(string connectionString) 
            : base(connectionString)
        { }

        /// <summary>
        /// Строки с данными авторизации пользователя в БД
        /// </summary>
        public DbSet<ReadableUserAuthorizeModel> UserAuthorizeDataRows { get; set; }

    }
}