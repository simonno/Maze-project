using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class BFS<TPriority> : Searcher<TPriority> where TPriority : IComparable<TPriority>
    {
        public override Solution search(ISearchable<TPriority> searchable)
        {
            pushOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State<TPriority>> closed = new HashSet<State<TPriority>>();
            while (OpenListSize > 0)
            {
                State<TPriority> n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n == searchable.getGoalState())
                    return backTrace(); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<TPriority>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<TPriority> s in succerssors)
                {
                    if (!closed.Contains(s) && !open.Containes(s))
                    {
                        // s.setCameFrom(n); // already done by getSuccessors
                        pushOpenList(s);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        private Solution backTrace()
        {
            throw new NotImplementedException();
        }
    }
}
