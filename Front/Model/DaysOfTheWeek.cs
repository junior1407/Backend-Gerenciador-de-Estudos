using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class DaysofTheWeek
    {
        public int Id { get; set; }
        public string nome { get; set; }
    
        public override string ToString()
        {
            return nome;
        }
        public DaysofTheWeek(string s)
        {
            nome = s;
        }
        public DaysofTheWeek()
        {

        }
    }
}
