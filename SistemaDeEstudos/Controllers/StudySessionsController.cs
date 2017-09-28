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
    public class StudySessionsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/StudySessions
        public IQueryable<StudySession> GetStudySessions()
        {
            return db.StudySessions;
        }

        // GET: api/StudySessions/5
        [ResponseType(typeof(StudySession))]
        public async Task<IHttpActionResult> GetStudySession(int id)
        {
            StudySession studySession = await db.StudySessions.FindAsync(id);
            if (studySession == null)
            {
                return NotFound();
            }

            return Ok(studySession);
        }

        // PUT: api/StudySessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudySession(int id, StudySession studySession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studySession.Id)
            {
                return BadRequest();
            }

            db.Entry(studySession).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudySessionExists(id))
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

        // POST: api/StudySessions
        [ResponseType(typeof(StudySession))]
        public async Task<IHttpActionResult> PostStudySession(StudySession studySession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudySessions.Add(studySession);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = studySession.Id }, studySession);
        }

        // DELETE: api/StudySessions/5
        [ResponseType(typeof(StudySession))]
        public async Task<IHttpActionResult> DeleteStudySession(int id)
        {
            StudySession studySession = await db.StudySessions.FindAsync(id);
            if (studySession == null)
            {
                return NotFound();
            }

            db.StudySessions.Remove(studySession);
            await db.SaveChangesAsync();

            return Ok(studySession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudySessionExists(int id)
        {
            return db.StudySessions.Count(e => e.Id == id) > 0;
        }
    }
}