using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class StudentSubject
    {
        public int Grade { get; set; }
        public string Subject { get; set; }

        public override string ToString()
        {
            return Subject + ", " + Grade;
        }
    }
}
