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
        [Key]
        public int Id { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        [Required]
        public int Grade { get; set; }

        public int IdSubject { get; set; }
        [ForeignKey("IdSubject")]
        public virtual Subject subject { get; set; }
    }
}