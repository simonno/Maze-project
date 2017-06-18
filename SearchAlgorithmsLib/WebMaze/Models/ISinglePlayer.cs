using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    interface ISinglePlayer
    {
        string GetName(int id);
        int GetCols(int id);
        int GetRows(int id);
        string GetStringMaze(int id);
    }
}
