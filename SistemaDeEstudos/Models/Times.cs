﻿using System;
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

        public int idUser{ get; set; }
        [ForeignKey("idUser")]
        public virtual User user { get; set; }

        public int idSession { get; set; }
        [ForeignKey("idSession")]
        public virtual StudySession Session { get; set; }

    }
}