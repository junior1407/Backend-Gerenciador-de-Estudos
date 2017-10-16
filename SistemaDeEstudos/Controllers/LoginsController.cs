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
    public class LoginsController : ApiController
    {
        private Model2 db = new Model2();

        [HttpPost]
        [Route("api/Logins/Refresh")]
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> GetRefreshToken(LoginToken l)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LoginToken loginToken = db.LoginTokens.FirstOrDefault(x => ((x.Token == l.Token) && (x.Reset_token==l.Reset_token)));
            if (default(LoginToken)==loginToken)
            {
                return Unauthorized();
            }
            LoginToken novo = new LoginToken();
            novo.IdUser = loginToken.IdUser;
            novo.Start = DateTime.UtcNow;
            novo.End = novo.Start.AddHours(1);
            novo.Token = Encrypt.getRandomString() + novo.IdUser;
            novo.Reset_token = Encrypt.getRandomString() + novo.IdUser;
            IEnumerable<LoginToken> oldTokens = db.LoginTokens.Where(x => x.IdUser == novo.IdUser);
            db.LoginTokens.RemoveRange(oldTokens);
            db.LoginTokens.Add(novo);
            db.SaveChanges();
            return Ok(novo);
        }
        //[Route("api/Logins/Login")]
        [HttpPost]
        [ResponseType(typeof(LoginToken))]
        public async Task<IHttpActionResult> PostLogin(LoginModel l)
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
            LoginToken token = new LoginToken();
            token.IdUser = login.IdUser;
            token.Start = DateTime.UtcNow;
            token.End = token.Start.AddHours(1);
            token.Token = Encrypt.getRandomString()+login.IdUser;
            token.Reset_token = Encrypt.getRandomString()+ login.IdUser;
            //DateTime now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, 
            // TimeZoneInfo.FindSystemTimeZoneById("065"));
            db.LoginTokens.Add(token);
            db.SaveChanges();
            return Ok(token);
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