using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMazeApp.Model
{
    public interface IUserManager
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User p);
        void UpdateUser(User p);
        void DeleteUser(int id);
    }
}