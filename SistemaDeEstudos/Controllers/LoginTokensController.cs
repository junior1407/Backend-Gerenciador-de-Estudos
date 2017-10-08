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
using System.Security.Cryptography;
using System.Text;
using SistemaDeEstudos.src;
using System.Web.Helpers;

namespace SistemaDeEstudos.Controllers
{
    public class LoginTokensController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/LoginTokens
        public IQueryable<LoginToken> GetLoginTokens()
        {
            return db.LoginTokens;
        }

        // GET: api/LoginTokens/5
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> GetLoginToken(int id)
        {
            LoginToken loginToken = await db.LoginTokens.FindAsync(id);
            if (loginToken == null)
            {
                return NotFound();
            }

            return Ok(loginToken);
        }

        // PUT: api/LoginTokens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLoginToken(int id, LoginToken loginToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginToken.Id)
            {
                return BadRequest();
            }

            db.Entry(loginToken).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginTokenExists(id))
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

       [Route("api/LoginTokens/Refresh")]
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> GetRefreshToken()
        {
            return Ok();
        }

        // POST: api/LoginTokens
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> PostLoginToken(Login l)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string password = Encrypt.encryptPassword(l.Password);
            List<Login> list = await db.Logins.Where(x => (x.Username == l.Username && x.Password == l.Password)).
                ToListAsync<Login>();
            if (list.Count()==0)
            {
                return BadRequest("Wrong Password");
            }
            DateTime now = DateTime.UtcNow;
            List<LoginToken> t = await db.LoginTokens.Where((x) => (x.End > now)).ToListAsync<LoginToken>();
            if (t.Count()>0 )
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
            token.Token = Encrypt.getRandomString()+ Request.Headers.ToString();
            token.Reset_token=Encrypt.getRandomString();
            //DateTime now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, 
            // TimeZoneInfo.FindSystemTimeZoneById("065"));
            db.LoginTokens.Add(token);
            await db.SaveChangesAsync();

            System.Diagnostics.Debug.WriteLine(Request.Headers.GetValues("Authorization").ElementAt(0));
         
            return Ok(token);
        }

        // DELETE: api/LoginTokens/5
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> DeleteLoginToken(int id)
        {
            LoginToken loginToken = await db.LoginTokens.FindAsync(id);
            if (loginToken == null)
            {
                return NotFound();
            }

            db.LoginTokens.Remove(loginToken);
            await db.SaveChangesAsync();

            return Ok(loginToken);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginTokenExists(int id)
        {
            return db.LoginTokens.Count(e => e.Id == id) > 0;
        }
    }
}