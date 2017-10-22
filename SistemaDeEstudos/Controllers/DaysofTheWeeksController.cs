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
    public class DaysofTheWeeksController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/DaysofTheWeeks
        public IQueryable<DaysofTheWeek> GetDaysofTheWeeks()
        {
            return db.DaysofTheWeeks;
        }

        // GET: api/DaysofTheWeeks/5
        [ResponseType(typeof(DaysofTheWeek))]
        public async Task<IHttpActionResult> GetDaysofTheWeek(int id)
        {
            DaysofTheWeek daysofTheWeek = await db.DaysofTheWeeks.FindAsync(id);
            if (daysofTheWeek == null)
            {
                return NotFound();
            }

            return Ok(daysofTheWeek);
        }

        // PUT: api/DaysofTheWeeks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDaysofTheWeek(int id, DaysofTheWeek daysofTheWeek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != daysofTheWeek.Id)
            {
                return BadRequest();
            }

            db.Entry(daysofTheWeek).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaysofTheWeekExists(id))
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

        // POST: api/DaysofTheWeeks
        [ResponseType(typeof(DaysofTheWeek))]
        public async Task<IHttpActionResult> PostDaysofTheWeek(DaysofTheWeek daysofTheWeek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DaysofTheWeeks.Add(daysofTheWeek);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = daysofTheWeek.Id }, daysofTheWeek);
        }

        // DELETE: api/DaysofTheWeeks/5
        [ResponseType(typeof(DaysofTheWeek))]
        public async Task<IHttpActionResult> DeleteDaysofTheWeek(int id)
        {
            DaysofTheWeek daysofTheWeek = await db.DaysofTheWeeks.FindAsync(id);
            if (daysofTheWeek == null)
            {
                return NotFound();
            }

            db.DaysofTheWeeks.Remove(daysofTheWeek);
            await db.SaveChangesAsync();

            return Ok(daysofTheWeek);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DaysofTheWeekExists(int id)
        {
            return db.DaysofTheWeeks.Count(e => e.Id == id) > 0;
        }
    }
}