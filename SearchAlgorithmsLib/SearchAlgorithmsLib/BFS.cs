using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    // public class BFS<TPriority> : Searcher<T,TPriority> where TPriority : IComparable<TPriority>
    public class BFS<T> : Searcher<T> 
    {
        public override Solution search(ISearchable<T> searchable)
        {//TO DO *missing a  return value solution  type?****
            State<T> start = searchable.GetInitialState();
            start.CameFrom = null;
            pushOpenList(start); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popFirst(); // inherited from Searcher, removes the best StateValue
                closed.Add(n);
                if (n == searchable.GetGoalState())
                    return backTrace(n); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.GetAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openList.Contains(s))
                    {
                        s.CameFrom = n;
                        pushOpenList(s);
                    }
                    else if (searchable.BetterDirection(n, s))
                    {
                        if (!openList.Contains(s))
                        {
                            s.CameFrom = n;
                            pushOpenList(s);
                        }
                        else
                        {
                            UpdatePlaceInOpen(s, s.cost);
                        }
                    }
                }
            }
        }

        private Solution backTrace(State<T> n)
        {
            List<State<T>> solution = new List<State<T>>();
            while (n != null)
            {
                solution.Add(n);
                n = n.CameFrom;
            } 
        }
    }
}
