using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class StudySessionParticipants
    {
        public int Id { get; set; }
      
        public int IdStudySession { get; set; }
        [ForeignKey("IdStudySession")]
        public virtual StudySession Session { get; set; }


        
        public int ParticipantID { get; set; }
        [ForeignKey("ParticipantID")]
        public virtual User Participant { get; set; }


    }
}