﻿    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeEstudos.Models
{
    public class RegisterInformationModel
    {

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string idRedeSocial { get; set; }    


    }
}