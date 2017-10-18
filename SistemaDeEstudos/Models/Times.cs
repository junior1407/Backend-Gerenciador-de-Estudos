using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class Times
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Start { get; set; }
        [Required]
        public string End { get; set; }
        [JsonIgnore]
        public int idUser{ get; set; }
        [ForeignKey("idUser"), JsonIgnore]
        public virtual User user { get; set; }

        [JsonIgnore]
        public int idDay { get; set; }
        [ForeignKey("idDay"), JsonIgnore]
        public virtual DaysofTheWeek day { get; set; }

        // [JsonIgnore]
        /*   public int idSession { get; set; }
           [ForeignKey("idSession"),   ]
           public virtual StudySession Session { get; set; }*/

    }
}