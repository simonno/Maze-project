using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebMaze.Models;
using System;



namespace WebMaze.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Users")]
    public class UsersControllerTemp : ApiController
    {
        private IUserManager usersManager = new UsersModel();



        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return usersManager.GetAllUsers();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        [Route("GetUser/{user}")]
        public User GetUser(string userName)
        {
            return usersManager.GetUser(userName);
        }

        //// PUT: api/Users/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutUser(int id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);


        //        if (id != user.Id)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            await db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}



        //// DELETE: api/Users/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> DeleteUser(int id)
        //{
        //    User user = await db.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();

        //    return Ok(user);
        //}


        // Post api/Users
        [HttpPost]
        //[Route("api/Users/register/{username}/{inputPassword}/{inputEmail}")]
        public IHttpActionResult Register(string username, string inputPassword, string inputEmail)
        {
            User user = new User { Username = username, Password = inputPassword, Email = inputEmail };
            int results = usersManager.Register(user);

            if (results == -1)
            {
                //return "-1";

                return Ok(new { error = "true", msg = "Register failed." });
            }
            // return "1";
            return Ok(new { error = "false", msg = "Register succeeded." });
        }
        // Post api/Users/login

        [HttpPost]
        //[Route("api/Users/login/{username}/{inputPassword}")]
        public IHttpActionResult Login(string username, string inputPassword)
        {
            int results = usersManager.Login(username, inputPassword);


            if (results == -1)
            {
                //return "-1";

                return Ok(new { error = "true", msg = "User is not exist." });
            }
             // return "1";
            return Ok(new { error = "false", msg = "User logged in." });

        }

        // Post api/Users/update
        [HttpPost]
        //[Route("api/Users/update/{username}/{mazeRows}/{mazeCols}/{SearchAlgo}")]
        public void Update(string username, int mazeRows, int mazeCols, int SearchAlgo)
        {
            usersManager.UpdateDefaultArgs(username, mazeRows, mazeCols, SearchAlgo);

        }


    }
}