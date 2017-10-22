using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
        [ScriptIgnore]
        public StudentSubject This { get { return this; } }
    }
}
