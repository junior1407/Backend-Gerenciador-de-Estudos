using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class TimesModel
    {

        public string Start { get; set; }
        public string End { get; set; }
        public DaysofTheWeek day { get; set; }
        public StudentSubject subject { get; set; }
    }
}