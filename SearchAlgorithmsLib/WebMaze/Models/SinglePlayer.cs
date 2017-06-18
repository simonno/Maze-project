using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class SinglePlayer
    {
       
        public string Mazename
        {
            get;
            set;
        }
        public int mazeRows
        {
            get;
            set;
        }

        public int mazeCols
        {
            get;
            set;
        }
        public string mazeString
        {
            get;
            set;
        }
        public int Id { get; set; }

    }
}