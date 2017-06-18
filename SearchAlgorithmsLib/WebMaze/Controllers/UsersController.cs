using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebMaze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WebMaze.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Users")]
    public class UsersController : ApiController
    {
        private IUserManager usersManager = new UsersModel();

        private WebMazeContext db = new WebMazeContext();
      

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
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
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
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

        // Get api/Users/register
        [Microsoft.AspNetCore.Mvc.HttpGet]
      //  [Microsoft.AspNetCore.Mvc.Route("api/Users/register")]
       // public IActionResult Register(User user)
        public bool Register(User user)
        {
            int results = usersManager.Register(user);

            Console.WriteLine("results :" + results);

            if (results == -1)
            {
                return false;
            }

            return true;
        }
        // Get api/Users/login
        [Microsoft.AspNetCore.Mvc.HttpGet]
        // [Route("api/Users/login")]
        // public IActionResult Login(LoginData login)
        public bool Login(LoginData login)
        {
            string username = login.Username;
            Console.WriteLine("name " + username);
            int results = usersManager.Login(login);

            Console.WriteLine("results :" + results);

            if (results == 1)
            {
                return false;
            }
            //return new ObjectResult(login);
            return true;

        }
    }
}