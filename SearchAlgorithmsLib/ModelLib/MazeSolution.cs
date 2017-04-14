using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class MazeSolution
    {
        private List<Position> solution;

        public List<Position> GetSolution()
        {
            return solution;
        }

        public int EvaluatedNodes { get; }

        public MazeSolution(int evaluatedNodes, List<Position> solution)
        {
            EvaluatedNodes = evaluatedNodes;
            this.solution = solution;
        }

    }
}

