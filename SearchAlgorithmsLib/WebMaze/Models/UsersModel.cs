using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class UsersModel : IUserManager
    {
        private WebMazeContext db = new WebMazeContext();

        private static List<User> users = new List<User>()
        {
            new User { Password = "1", Username = "laptop", Email = "1000" },
            new User { Password = "2", Username = "tablet", Email = "200" },
            new User { Password = "3", Username = "smartphone", Email = "1200" }
        };
        

        public void AddUser(User p)
        {
            users.Add(p);
            db.Users.Add(p);
            db.SaveChanges();

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

        public User GetUserById(int id)
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        public void UpdateUser(User p)
        {
            User prod = users.Where(x => x.Id == p.Id).FirstOrDefault();
            prod.Username = p.Username;
            prod.Password = p.Password;
            prod.Email = p.Email;
        }
        
        public int Login(string username, string password)
        {
            User user = users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                if (user.Password == password)
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
            db.Users.Add(user);
            db.SaveChanges();

            return 1;
        }
        public int GetDefaultAlgo(int id)
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            return p.DefaultAlgo;
        }
        public int GetDefaultCols(int id)
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            return p.DefaultCols;
        }
        public int GetDefaultRows(int id)
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            return p.DefaultRows;
        }
        public void UpdateDefaultArgs(int id,int rows,int cols,int defaultAlgo)
        {
            User prod = users.Where(x => x.Id == id).FirstOrDefault();
            prod.DefaultRows = rows;
            prod.DefaultCols = cols;
            prod.DefaultAlgo =defaultAlgo;
        }
    }
}
