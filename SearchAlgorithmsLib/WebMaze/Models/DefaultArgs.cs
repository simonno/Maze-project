using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class DefaultArgs
    {
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

        public int Id { get; set; }
    }
}