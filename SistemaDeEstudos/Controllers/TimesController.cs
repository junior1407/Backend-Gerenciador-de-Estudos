using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaDeEstudos.Models;
using SistemaDeEstudos.src;

namespace SistemaDeEstudos.Controllers
{
    public class TimesController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Times
        public async Task<IHttpActionResult> GetTimes()
        {
            try
            {
                string token = Request.Headers.GetValues("Authorization").ElementAt(0);

                User u = Encrypt.getUser(token, db);
              //  System.Diagnostics.Debug.WriteLine("Token" + token);
               // System.Diagnostics.Debug.WriteLine("User:" + u);
                if (u == default(User))
                {
                    return Unauthorized();
                }
                IEnumerable<Times> times = db.Times.Where(x => x.idUser == u.Id);
                return Ok(times.ToList());
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
        }
     
        // POST: api/Times
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostTimes(IEnumerable<Times> times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //    db.Times.Add(times);
            //  await db.SaveChangesAsync();
            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = times.Id }, times);
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimesExists(int id)
        {
            return db.Times.Count(e => e.Id == id) > 0;
        }
    }
}