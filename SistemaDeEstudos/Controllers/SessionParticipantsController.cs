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
    public class SessionParticipantsController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/SessionParticipants
        public IQueryable<SessionParticipants> GetSessionParticipants()
        {
            return db.SessionParticipants;
        }

        // GET: api/SessionParticipants/5
        [ResponseType(typeof(SessionParticipants))]
        public async Task<IHttpActionResult> GetSessionParticipants(int id)
        {
            SessionParticipants sessionParticipants = await db.SessionParticipants.FindAsync(id);
            if (sessionParticipants == null)
            {
                return NotFound();
            }

            return Ok(sessionParticipants);
        }

        // PUT: api/SessionParticipants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSessionParticipants(int id, SessionParticipants sessionParticipants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionParticipants.Id)
            {
                return BadRequest();
            }

            db.Entry(sessionParticipants).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionParticipantsExists(id))
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

        // POST: api/SessionParticipants
        [ResponseType(typeof(SessionParticipants))]
        public async Task<IHttpActionResult> PostSessionParticipants(SessionParticipants sessionParticipants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SessionParticipants.Add(sessionParticipants);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sessionParticipants.Id }, sessionParticipants);
        }

        // DELETE: api/SessionParticipants/5
        [ResponseType(typeof(SessionParticipants))]
        public async Task<IHttpActionResult> DeleteSessionParticipants(int id)
        {
            SessionParticipants sessionParticipants = await db.SessionParticipants.FindAsync(id);
            if (sessionParticipants == null)
            {
                return NotFound();
            }

            db.SessionParticipants.Remove(sessionParticipants);
            await db.SaveChangesAsync();

            return Ok(sessionParticipants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionParticipantsExists(int id)
        {
            return db.SessionParticipants.Count(e => e.Id == id) > 0;
        }
    }
}