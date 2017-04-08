﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    // public class BFS<TPriority> : Searcher<T,TPriority> where TPriority : IComparable<TPriority>
    public class BFS<T> : Searcher<T>  where T : IComparable<T>

    {
        public override Solution search(ISearchable<T> searchable)
        {//TO DO *missing a  return value solution  type?****
            pushOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n == searchable.getGoalState())
                    return backTrace(); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openContaines(s))
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
