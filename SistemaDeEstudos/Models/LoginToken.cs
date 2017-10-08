using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstudos.Models
{
    public class LoginToken
    {

        [Key,JsonIgnore]
        public int Id { get; set; }
        public string Token { get; set; }
        public string Reset_token { get; set; }
        [DataType(DataType.Date), JsonIgnore]
        public DateTime Start { get; set; }
        [DataType(DataType.Date), JsonIgnore]
        public DateTime End { get; set; }
        [ JsonIgnore]
        public int IdUser { get; set; }
        [ForeignKey("IdUser"), JsonIgnore]
        public virtual User Student { get; set; }
    }

}