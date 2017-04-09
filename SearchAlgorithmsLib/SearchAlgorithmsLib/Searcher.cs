using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T> where T : IComparable<T>
    {
        protected SimplePriorityQueue<State<T>, State<T>> openList;
        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        private int evaluatedNodes;
        public Searcher()
        {
            openList = new SimplePriorityQueue<State<T>, State<T>>();
            evaluatedNodes = 0;
        }

        protected void pushOpenList(State<T> s)
        {
            openList.Enqueue(s, s);
        }

        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.First;
        }
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public abstract Solution search(ISearchable<T> searchable);
    }
}
