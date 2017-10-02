using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Avatar { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string idRedeSocial { get; set; }

        //    public virtual ICollection<Times> Times { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentGrade> Grades { get; set; }
    }   
}