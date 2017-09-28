using SistemaDeEstudos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SistemaDeEstudos.Controllers
{
    public class GeneralController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
