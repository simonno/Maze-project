using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T> where T : IComparable<T>

        // public abstract class Searcher<T, TPriority> : ISearcher<T> where TPriority : IComparable<TPriority>
    {
        //private SimplePriorityQueue<State<T>, PriorityComparator<T>> openList;
        private  MyPriorityQueue<State<T>> openList;
        private int evaluatedNodes;
        public Searcher()
        {
            //  openList = new SimplePriorityQueue<State<T>, PriorityComparator<T>>();
            openList = new SimplePriorityQueue<State<T>>();

            evaluatedNodes = 0;
        }

        protected void pushOpenList(State<T> s)
        {
            openList.Enqueue(s, 2);
        }

        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.First;
        }
        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public abstract Solution search(ISearchable<T> searchable);



    }
}
