using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMazeApp
{
    public class User
    {
        public string Username
        {
            get;
            set;
        }
        public int Id { get; set; }
        public string Password
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}