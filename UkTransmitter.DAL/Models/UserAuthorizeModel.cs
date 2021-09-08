using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UkSender.CommonLibrary.Models
{
    [Table("tUsers", Schema = "dataUk")]
    public class UserAuthorizeModel
    {
        [Key]
        public int Id           { get; set; }
        public string Login     { get; set; }
        public string Pwd       { get; set; }
    }
}
