using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class StudentGrade
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int IdUser { get; set; }
        [ForeignKey("IdUser"), JsonIgnore]
        public virtual User User { get; set; }

        [Required]
        public int Grade { get; set; }
        [JsonIgnore]
        public int IdSubject { get; set; }
        [ForeignKey("IdSubject")]
        public virtual Subject subject { get; set; }
    }
}