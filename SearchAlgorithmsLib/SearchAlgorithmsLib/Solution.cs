using System.Collections.Generic;

namespace SearchAlgorithmsLib
{
    public class Solution<S, C>
    {
        private int evaluatedNodes;
        private List<State<S, C>> solution;
    
        public List<State<S, C>> GetSolution()
        {
            return solution;
        }

        public int GetEvaluatedNodes()
        {
            return evaluatedNodes;
        }

        public Solution(List<State<S, C>> solution, int evaluatedNodes)
        {
            this.solution = solution;
            this.evaluatedNodes = evaluatedNodes;
        }
    }
}