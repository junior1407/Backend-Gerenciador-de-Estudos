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
        public async Task<IHttpActionResult> PostTimes(IEnumerable<TimesModel> times)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string token = Request.Headers.GetValues("Authorization").ElementAt(0);

             User u = Encrypt.getUser(token, db);
                if (u == default(User))
                {
                    return Unauthorized();
                }

                IEnumerable<Times> remove = db.Times.Where(x => x.idUser == u.Id);

               foreach(Times x in remove)
                {
                    db.Times.Remove(x);
                }
                await db.SaveChangesAsync();
                List<Times> list = new List<Times>();
                
                foreach (TimesModel x in times)
                {
                    //Fix subject.  
                    x.subject = db.StudentSubjects.FirstOrDefault(y => (y.IdUser == u.Id && y.Subject==x.subject.Subject));
                    System.Diagnostics.Debug.WriteLine(x);
                    list.Add(new Times() { Start = x.Start, idDay = x.day.Id, End = x.End, idUser = u.Id, idSubject = x.subject.Id });   
                }
                db.Times.AddRange(list);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
            catch(DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }







           
            // System.Diagnostics.Debug.WriteLine(times);

           
           

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