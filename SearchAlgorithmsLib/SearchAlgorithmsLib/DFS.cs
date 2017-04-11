using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<S, C> : ISearcher<S, C>
    {
        private int evaluatedNodes;

        public DFS()
        {
            evaluatedNodes = 0;
        }

        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public List<State<S, C>> Search(ISearchable<S, C> searchable)
        {
            State<S, C> s;
            //For DFS use stack
            Stack<State<S, C>> stack = new Stack<State<S, C>>();
            evaluatedNodes++;
            stack.Push(searchable.GetInitialState());

            while (stack.Count != 0)
            {
                s = stack.Pop();

                if (s == searchable.GetGoalState())
                    return backTrace(s);

                foreach (State<S, C> i in searchable.GetAllPossibleStates(s))
                {
                    if (i.CameFrom == null)
                    {
                        evaluatedNodes++;
                        i.CameFrom = s;
                        stack.Push(i);
                    }
                }
            }
            return null;
        }

        

        private List<State<S, C>> backTrace(State<S, C> n)
        {
            List<State<S, C>> solution = new List<State<S, C>>();
            while (n != null)
            {
                solution.Add(n);
                n = n.CameFrom;
            }
            return solution;
        }
    }
}
