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
using SistemaDeEstudos.Controllers;
using SistemaDeEstudos.src;
using System.Data.Entity;

namespace SistemaDeEstudos.Controllers
{
    public class StudentGradesController : ApiController
    {
        private Model2 db = new Model2();

        [ResponseType(typeof(IEnumerable<StudentGrade>))]
        public IHttpActionResult GetStudentGrade(int id)
        {
         //   db.Configuration.ProxyCreationEnabled = false;
            try
            {
                string token = Request.Headers.GetValues("Authorization").ElementAt(0);

                if (Encrypt.isAuthorized(token, id, db) == false)
                {
                    System.Diagnostics.Debug.WriteLine("token~ "+token);
                    return Unauthorized();
                }
                IEnumerable<StudentGrade> grades = db.StudentGrades.Where(x => x.IdUser == id);
                   System.Diagnostics.Debug.WriteLine("tam:"+grades.Count());
                return Ok(grades.ToList());
            }
            catch(InvalidOperationException e)
            {
                return BadRequest();
            }
        }

        // PUT: api/StudentGrades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentGrade(int id, StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentGrade.Id)
            {
                return BadRequest();
            }

            db.Entry(studentGrade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGradeExists(id))
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

        // POST: api/StudentGrades
        [ResponseType(typeof(StudentGrade))]
        public async Task<IHttpActionResult> PostStudentGrade(StudentGrade studentGrade)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentGrades.Add(studentGrade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = studentGrade.Id }, studentGrade);
        }

        // DELETE: api/StudentGrades/5
        [ResponseType(typeof(StudentGrade))]
        public async Task<IHttpActionResult> DeleteStudentGrade(int id)
        {
            StudentGrade studentGrade = await db.StudentGrades.FindAsync(id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            db.StudentGrades.Remove(studentGrade);
            await db.SaveChangesAsync();

            return Ok(studentGrade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentGradeExists(int id)
        {
            return db.StudentGrades.Count(e => e.Id == id) > 0;
        }
    }
}