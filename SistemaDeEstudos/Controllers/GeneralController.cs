using SistemaDeEstudos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaDeEstudos.Controllers
{
    public class GeneralController : ApiController
    {
        private Model1 db = new Model1();
        // GET: api/Logins
        public IQueryable<Login> GetLogins()
        {
            return db.Logins;
        }
    }
}
