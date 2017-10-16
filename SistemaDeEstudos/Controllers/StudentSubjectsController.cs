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
    public class StudentSubjectsController : ApiController
    {
        private Model2 db = new Model2();


        [ResponseType(typeof(IEnumerable<StudentSubject>))]
        public IHttpActionResult getStudentSubjects()
        {
            try
            {
                string token = Request.Headers.GetValues("Authorization").ElementAt(0);

                User u = Encrypt.getUser(token, db);
                System.Diagnostics.Debug.WriteLine("Token" + token);
                System.Diagnostics.Debug.WriteLine("User:" +u);
                if (u==default(User))
                {
                    return Unauthorized();
                }
                IEnumerable<StudentSubject> grades = db.StudentSubjects.Where(x => x.IdUser == u.Id);
                return Ok(grades.ToList());
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(IEnumerable<StudentSubject>))]
        public IHttpActionResult GetStudentSubject(int id)
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
                IEnumerable<StudentSubject> grades = db.StudentSubjects.Where(x => x.IdUser == id);
                   System.Diagnostics.Debug.WriteLine("tam:"+grades.Count());
                return Ok(grades.ToList());
            }
            catch(InvalidOperationException e)
            {
                return BadRequest();
            }
        }

        // POST: api/StudentSubjects
        [ResponseType(typeof(StudentSubject))]
        public async Task<IHttpActionResult> PostStudentSubject(StudentSubject StudentSubject)
        {
            try
            {
                string token = Request.Headers.GetValues("Authorization").ElementAt(0);

                User u = Encrypt.getUser(token, db);
                System.Diagnostics.Debug.WriteLine("Token" + token);
                System.Diagnostics.Debug.WriteLine("User:" + u);
                if (u == default(User))
                {
                    return Unauthorized();
                }
                StudentSubject.IdUser = u.Id;
               
                db.StudentSubjects.Add(StudentSubject);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
        }

        [Route("api/StudentSubjects/Delete")]
        [HttpPost]
        [ResponseType(typeof(StudentSubject))]
        public async Task<IHttpActionResult> DeleteStudentSubject(StudentSubject s)
        {
            try
            {
                string token = Request.Headers.GetValues("Authorization").ElementAt(0);
                User u = Encrypt.getUser(token, db);
                if (u==default(User))
                {
                    return Unauthorized();
                }
                StudentSubject g = await db.StudentSubjects.FirstOrDefaultAsync(x => ((x.IdUser == u.Id) && ( x.Subject==s.Subject)  ));
                if (g == default(StudentSubject))
                {
                    return BadRequest();
                }
                db.StudentSubjects.Remove(g);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
        }
        /*

        StudentSubject StudentSubject = await db.StudentSubjects.FindAsync(id);
        if (StudentSubject == null)
        {
            return NotFound();
        }

        db.StudentSubjects.Remove(StudentSubject);
        await db.SaveChangesAsync();

        return Ok(StudentSubject);*/
    

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentSubjectExists(int id)
        {
            return db.StudentSubjects.Count(e => e.Id == id) > 0;
        }
    }
}