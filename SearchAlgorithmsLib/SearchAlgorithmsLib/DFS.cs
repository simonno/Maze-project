using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : Searcher<T> where T : IComparable<T>
    {
        public override Solution search(ISearchable<T> searchable, State<T> newState, int Vertices, int newIndex)
        {
            bool[] visited = new bool[Vertices];
            State<T> s;
            //For DFS use stack
            Stack<State<T>> stack = new Stack<State<T>>();
            visited[newIndex] = true;
            stack.Push(newState);

            while (stack.Count != 0)
            {
                s = stack.Pop();

                foreach (State<T> i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
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
