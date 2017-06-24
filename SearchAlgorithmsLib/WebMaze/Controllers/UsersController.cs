using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class UsersController : ApiController
    {
        private WebMazeContext db = new WebMazeContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string username)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // encrypting the password.
            SHA1 s = SHA1.Create();
            byte[] buffer = Encoding.ASCII.GetBytes(user.Password);
            byte[] hashCode = s.ComputeHash(buffer);
            user.Password = Convert.ToBase64String(hashCode);

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { username = user.Username }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

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

        private bool UserExists(string username)
        {
            return db.Users.Count(e => e.Username == username) > 0;
        }

        // POST: api/Users
        [HttpPost]
        public IHttpActionResult Login(string username, string password)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);
     

            if (user != null)
            {
                // encrypting the password.
                SHA1 s = SHA1.Create();
                byte[] buffer = Encoding.ASCII.GetBytes(password);
                byte[] hashCode = s.ComputeHash(buffer);
                string encryptedPassword = Convert.ToBase64String(hashCode);
                if (user.Password == encryptedPassword)
                {
                   return BadRequest("username or password incorrect.");
                }
            }
            return NotFound();
        }
    }
}


//// PUT: api/Users/5
//[ResponseType(typeof(void))]
//public IHttpActionResult PutUser(int id, User user)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    if (id != user.Id)
//    {
//        return BadRequest();
//    }

//    db.Entry(user).State = EntityState.Modified;

//    try
//    {
//        db.SaveChanges();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!UserExists(id))
//        {
//            return NotFound();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return StatusCode(HttpStatusCode.NoContent);
//}