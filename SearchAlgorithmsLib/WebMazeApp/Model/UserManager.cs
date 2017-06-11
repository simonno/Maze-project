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
    }
}