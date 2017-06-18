﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMaze.Models
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
        public int defaultRows
        {
            get;
            set;
        }

        public int defaultCols
        {
            get;
            set;
        }
        public int defaultAlgo
        {
            get;
            set;
        }

    }
}