﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : ISearcher<T>
    {
        public int getNumberOfNodesEvaluated()
        {
            throw new NotImplementedException();
        }

        public override Solution search(ISearchable<T> searchable)
        {
            State<T> s;
            //For DFS use stack
            Stack<State<T>> stack = new Stack<State<T>>();
            stack.Push(searchable.GetInitialState());

            while (stack.Count != 0)
            {
                s = stack.Pop();

                if (s == searchable.GetGoalState())
                    return backTrace();

                foreach (State<T> i in searchable.GetAllPossibleStates(s))
                {
                    if (i.CameFrom == null)
                    {
                        i.CameFrom = s;
                        stack.Push(i);
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
