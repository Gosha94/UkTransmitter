﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UkSender.CommonLibrary.Models
{

    #if DEBUG
        [Table("email.tEmailData_Test")]
    #endif
    
    #if !DEBUG
        [Table("email.tEmailData")]
    #endif

    public class EmailModel
    {
        [Key]
        public int Id                 { get; set; }
        public string FromAddress     { get; set; }
        public string FromName        { get; set; }        
        public string ToAddress       { get; set; }
        public string SecondToAddress { get; set; }
        public string SubjectPiece    { get; set; }        
        public string Lg              { get; set; }
        public string Pw              { get; set; }       
    }
}
