using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using WebMazeApp.Model;

namespace WebMazeApp.Controllers
{


    public class UsersController : ApiController
    {

        private IUserManager userManager = new UserManager();

        // GET: api/Products
        public IEnumerable<User> GetAllUsers()
        {
            return userManager.GetAllUsers();
        }

        // GET: api/Products/5
        public User GetUserById(int id)
        {
            return userManager.GetUserById(id);
        }

        // POST: api/Products
        [HttpPost]
        public User AddProduct(User p)
        {
            userManager.AddUser(p);
            return p;
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            userManager.DeleteUser(id);
        }
    }
}