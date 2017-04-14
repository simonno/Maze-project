using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public interface ISearcher<S, C>
    {
        // the search method
        Solution<S, C> Search(ISearchable<S, C> searchable);
        // get how many nodes were evaluated by the algorithm
        int getNumberOfNodesEvaluated();
    }
}
