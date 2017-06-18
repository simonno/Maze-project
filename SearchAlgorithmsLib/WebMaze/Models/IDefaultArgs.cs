using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    interface IDefaultArgs
    {
        int GetDefaultAlgo(int id);
        int GetDefaultCols(int id);
        int GetDefaultRows(int id);
        void UpdateDefaultArgs(DefaultArgs d);

    }
}
