using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class MazeSolution
    {
        public string GameName
        {
            get; set;
        }
        
        public string SolutionString
        {
            set; get;
        }
        public List<Position> Solution
        {
            get; set;
        }

        public int EvaluatedNodes { get; set; }

        public string ToJSON()
        {
            JObject obj = new JObject();
            obj["Name"] = GameName;
            obj["Solution"] = FromListToString();
            obj["NodesEvaluated"] = EvaluatedNodes;
            return obj.ToString();
        }
        public static MazeSolution FromJSON(string str)
        {
            MazeSolution ms = new MazeSolution();
            JObject obj = JObject.Parse(str);
            ms.GameName = (string)obj["Name"];
            ms.SolutionString = (string)obj["Solution"];
            ms.EvaluatedNodes = (int)obj["NodesEvaluated"];
            return ms;
        }

        private string FromListToString()
        {
            string solution = "";
            for (int i = 1; i < Solution.Count; i++)
            {
                solution += ComparePosition(Solution[i - 1], Solution[i]).ToString();
            }
            return solution;
        }

        private int ComparePosition(Position p1, Position p2)
        {
            if (p2.Row < p1.Row) { return 0; }
            if (p2.Row > p1.Row) { return 1; }
            if (p2.Col < p1.Col) { return 2; }
            return 3; //  if (p2.Col > p1.Col) 
        }

    }
}

