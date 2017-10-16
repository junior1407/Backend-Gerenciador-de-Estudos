using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class StudySession
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime start { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime end { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser"), JsonIgnore]
        public virtual User Responsible { get; set; }
        
        public int IdStudentSubject { get; set; }
        [ForeignKey("IdStudentSubject"), JsonIgnore]
        public virtual StudentSubject  Subject { get; set; }



       // public virtual ICollection<User> participants { get; set; }




    }
}