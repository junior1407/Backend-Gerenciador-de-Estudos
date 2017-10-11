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
    public class LoginsController : ApiController
    {
        private Model2 db = new Model2();

        public IQueryable<Login> GetLogins()
        {
            return db.Logins;
        }
        [ResponseType(typeof(Login))]
        public async Task<IHttpActionResult> GetLogin(int id)
        {
            Login login = await db.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }


        [Route("api/Logins/Login")]
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> Login(LoginModel l)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
               Login login = db.Logins.FirstOrDefault(x => (x.Username == l.Username && x.Password == l.Password));
            if (login == default(Login))
            {
                return Unauthorized();
            }

            IEnumerable<LoginToken> oldTokens = db.LoginTokens.Where(x => x.IdUser == login.IdUser);
            db.LoginTokens.RemoveRange(oldTokens);
            System.Diagnostics.Debug.WriteLine(oldTokens);
            db.SaveChanges();
            return Ok(login);
            /*
             if (await db.Logins.AnyAsync(x=> x.Username == l.Username && x.Password==l.Password))
             {*/
            //System.Diagnostics.Debug.WriteLine(login.ToString()+ "tipo:"+ login.GetType().ToString());
        //    return Ok("{\"Message\": \"Ja tem login\"");


              //  DateTime now = DateTime.UtcNow;
               /* List<LoginToken> t = await db.LoginTokens.Where((x) => (x.End > now)).ToListAsync<LoginToken>();
                if (t.Count() > 0)
                {
                    LoginToken selected = t[0];
                    db.LoginTokens.Attach(selected);
                    selected.End = DateTime.UtcNow.AddHours(1);
                    await db.SaveChangesAsync();
                    return Ok(selected);
                }

                LoginToken token = new LoginToken();
                token.IdUser = list[0].IdUser;
                token.Start = DateTime.UtcNow;
                token.End = token.Start.AddHours(1);
                token.Token = Encrypt.getRandomString() + Request.Headers.ToString();
                token.Reset_token = Encrypt.getRandomString();
                //DateTime now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, 
                // TimeZoneInfo.FindSystemTimeZoneById("065"));
                db.LoginTokens.Add(token);
                await db.SaveChangesAsync();

                System.Diagnostics.Debug.WriteLine(Request.Headers.GetValues("Authorization").ElementAt(0));


           
    */





         //   }
         //   return BadRequest("Credenciais erradas");
          }


        // PUT: api/Logins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLogin(int id, Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.Id)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        [ResponseType(typeof(Login))]
        public async Task<IHttpActionResult> PostLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Logins.Add(login);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = login.Id }, login);
        }

        // DELETE: api/Logins/5
        [ResponseType(typeof(Login))]
        public async Task<IHttpActionResult> DeleteLogin(int id)
        {
            Login login = await db.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            db.Logins.Remove(login);
            await db.SaveChangesAsync();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginExists(int id)
        {   
            return db.Logins.Count(e => e.Id == id) > 0;
        }
    }
}