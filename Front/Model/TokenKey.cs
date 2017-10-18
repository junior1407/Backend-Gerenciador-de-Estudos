using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class TokenKey
    {
        public string Token { get; set; }
        public string Reset_token { get; set; }

        public override string ToString()
        {
            return String.Format("token {0}, refresh {1}", Token, Reset_token);
        }
    }
  
}
