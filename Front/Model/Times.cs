using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class Times
    {
        public string Start { get; set; }
        public string End { get; set; }
        public DaysofTheWeek day { get; set; }
        public StudentSubject subject { get; set; }

    }
}
