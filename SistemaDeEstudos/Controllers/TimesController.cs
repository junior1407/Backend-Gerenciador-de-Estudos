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

namespace SistemaDeEstudos.Controllers
{
    public class TimesController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Times
        public IQueryable<Times> GetTimes()
        {
            return db.Times;
        }

        // GET: api/Times/5
        [ResponseType(typeof(Times))]
        public async Task<IHttpActionResult> GetTimes(int id)
        {
            Times times = await db.Times.FindAsync(id);
            if (times == null)
            {
                return NotFound();
            }

            return Ok(times);
        }

        // PUT: api/Times/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTimes(int id, Times times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != times.Id)
            {
                return BadRequest();
            }

            db.Entry(times).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Times
        [ResponseType(typeof(Times))]
        public async Task<IHttpActionResult> PostTimes(Times times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Times.Add(times);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = times.Id }, times);
        }

        // DELETE: api/Times/5
        [ResponseType(typeof(Times))]
        public async Task<IHttpActionResult> DeleteTimes(int id)
        {
            Times times = await db.Times.FindAsync(id);
            if (times == null)
            {
                return NotFound();
            }

            db.Times.Remove(times);
            await db.SaveChangesAsync();

            return Ok(times);
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