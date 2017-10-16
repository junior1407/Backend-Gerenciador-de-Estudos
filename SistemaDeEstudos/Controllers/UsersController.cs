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
    public class UsersController : ApiController
    {
        private Model2 db = new Model2();
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != user.Id)
            {
                return BadRequest();
            }
            db.Entry(user).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(RegisterInformationModel r)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User u = new Models.User { Avatar = r.Avatar,
                idRedeSocial = r.idRedeSocial,
                Nickname = r.Nickname };
            if (db.Logins.Where(x=>x.Username == r.Username).Count()>0)
            {
                return BadRequest();
            }
            db.Users.Add(u);
            await db.SaveChangesAsync();
            System.Diagnostics.Debug.WriteLine(u.Id);
            return CreatedAtRoute("DefaultApi", new { }, u); //new { id = user.Id }, user);
        }   

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}