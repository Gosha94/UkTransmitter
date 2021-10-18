using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UkTransmitter.Core.CommonModels
{

    /// <summary>
    /// Модель данных авторизации пользователей в БД
    /// </summary>
    [Table("tUsers", Schema = "dataUk")]
    public class ReadableUserAuthorizeModel
    {
        [Key]
        public int Id           { get; set; }
        public string Login     { get; set; }
        public string Pwd       { get; set; }
    }
}