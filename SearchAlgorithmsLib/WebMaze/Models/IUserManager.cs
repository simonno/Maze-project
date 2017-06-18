using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    interface IUserManager
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User p);
       void UpdateUser(User p);
        void DeleteUser(int id);
        int Register(User user);
        int Login(LoginData login);


    }
}
