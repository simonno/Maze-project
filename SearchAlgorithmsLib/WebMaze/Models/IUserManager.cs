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
        int GetDefaultAlgo(int id);
        int GetDefaultCols(int id);
        int GetDefaultRows(int id);
        void UpdateDefaultArgs(int id, int rows, int cols, int defaultAlgo);

    }


}

