using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class DetaultArgsModel:IDefaultArgs
    {
        private static List<DefaultArgs> defaultArgs = new List<DefaultArgs>()
        {
            new DefaultArgs { defaultCols = 1,defaultRows = 1, defaultAlgo = 0 },
            new DefaultArgs { defaultCols = 2, defaultRows = 8, defaultAlgo = 1 },
            new DefaultArgs { defaultCols = 3, defaultRows = 3, defaultAlgo = 0 }
        };
        public int GetDefaultAlgo(int id)
        {
            DefaultArgs p = defaultArgs.Where(x => x.Id == id).FirstOrDefault();
            return p.defaultAlgo;
        }
        public int GetDefaultCols(int id){
            DefaultArgs p = defaultArgs.Where(x => x.Id == id).FirstOrDefault();
            return p.defaultCols;
        }
        public int GetDefaultRows(int id)
        {
            DefaultArgs p = defaultArgs.Where(x => x.Id == id).FirstOrDefault();
            return p.defaultRows;
        }
       public void UpdateDefaultArgs(DefaultArgs d)
        {
            DefaultArgs prod = defaultArgs.Where(x => x.Id == d.Id).FirstOrDefault();
            prod.defaultRows = d.defaultRows;
            prod.defaultCols = d.defaultCols;
            prod.defaultAlgo = d.defaultAlgo;
        }

    }
}