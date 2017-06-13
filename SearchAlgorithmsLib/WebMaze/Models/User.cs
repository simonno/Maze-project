﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMaze
{
    public class User
    {
        [Required]
        public string Username
        {
            get;
            set;
        }
        public int Id { get; set; }
        [Required]
        public string Password
        {
            get;
            set;
        }
        [Required]

        public string Email
        {
            get;
            set;
        }
    }
}