using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class UsersModel : IUserManager
    {
        private static List<User> users = new List<User>()
        {
            new User { Password = "1", Username = "laptop", Email = "1000" },
            new User { Password = "2", Username = "tablet", Email = "200" },
            new User { Password = "3", Username = "smartphone", Email = "1200" }
        };
        

        public void AddUser(User p)
        {
            users.Add(p);
        }

        public void DeleteUser(int id)
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
                throw new Exception("product not found");
            users.Remove(p);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public User GetProductById(int id)
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        public void UpdateProduct(User p)
        {
            User prod = users.Where(x => x.Id == p.Id).FirstOrDefault();
            prod.Username = p.Username;
            prod.Password = p.Password;
            prod.Email = p.Email;
        }
        public User GetUserById(int id)
        {
            User prod = users.Where(x => x.Id ==id).FirstOrDefault();
            return prod;
        }
        public int Login(LoginData login)
        {
            User user = users.FirstOrDefault(u => u.Username == login.Username);

            if (user != null)
            {
                if (user.Password == login.Password)
                {
                    return 1;
                }
            }

            return -1;
        }

        public int Register(User user)
        {
            if (users.Contains(user))
            {
                return -1;
            }

            users.Add(user);
            return 1;
        }
    }
}
