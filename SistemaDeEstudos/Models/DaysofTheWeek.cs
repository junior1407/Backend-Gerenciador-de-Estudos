using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class DaysofTheWeek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string nome { get; set; }
    }
}