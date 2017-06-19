using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class UsersModel : IUserManager
    {
        private WebMazeContext db = new WebMazeContext();
        

        public void AddUser(User p)
        {
            db.Users.Add(p);
            db.SaveChanges();
        }

        public IQueryable<User> GetAllUsers()
        {
            return db.Users;
        }

        public User GetUser(string userName)
        {
            return db.Users.FirstOrDefault(u => u.Username == userName);
        }

        public void UpdateUser(User p)
        {
            User prod = db.Users.Where(x => x.Id == p.Id).FirstOrDefault();
            prod.Username = p.Username;
            prod.Password = p.Password;
            prod.Email = p.Email;
        }
        
        public int Login(string username, string password)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);

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
