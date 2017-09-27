﻿using System;
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
        [ForeignKey("IdUser")]
        public virtual User Responsible { get; set; }

        public int IdSubject { get; set; }
        [ForeignKey("IdSubject")]
        public virtual Subject Subject { get; set; }



        public virtual ICollection<User> participants { get; set; }




    }
}