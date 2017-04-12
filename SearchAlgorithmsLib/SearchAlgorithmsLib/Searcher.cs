using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<S, C> : ISearcher<S, C>
    {
        protected SimplePriorityQueue<State<S, C>, State<S, C>.ICost<C>> openList;
        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        private int evaluatedNodes;
        public Searcher()
        {
            openList = new SimplePriorityQueue<State<S, C>, State<S, C>.ICost<C>>();
            evaluatedNodes = 0;
        }

        protected void pushOpenList(State<S, C> s)
        {
            evaluatedNodes++;
            openList.Enqueue(s, s.cost);
        }

        protected State<S,C> popFirst()
        {
            return openList.First;
        }

        protected State<S, C> popOpenList()
        {
            return openList.Dequeue();
        }
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        protected void UpdatePlaceInOpen(State<S, C> s, State<S,C>.ICost<C> c)
        {
            evaluatedNodes++;
            openList.UpdatePriority(s, c);
        }

        public abstract List<State<S, C>> Search(ISearchable<S, C> searchable);
    }
}
