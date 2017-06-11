using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMazeApp.Model
{
    public class UserManager : IUserManager
    {
        private static List<User> users = new List<User>()
        {
            new User { Username = "laptop", Password = "1",Email="d1" },
            new User { Username = "laptop2", Password = "12",Email="d2" },
            new User { Username = "laptop3", Password = "123",Email="d3" },
        };

        public void AddUser(User p)
        {
            users.Add(p);
        }

        public void DeleteUser(int id )
        {
            User p = users.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
                throw new Exception("user not found");
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
            User user1 = users.Where(x => x.Id == p.Id).FirstOrDefault();
            user1.Username = p.Username;
            user1.Password = p.Password;
            user1.Email = p.Email;
        }

    }
}