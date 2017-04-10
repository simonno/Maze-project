using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public interface ISearchable<S, C>
    {
        State<S, C> GetInitialState();
        State<S, C> GetGoalState();
        List<State<S, C>> GetAllPossibleStates(State<S, C> s);
        bool BetterDirection(State<S, C> s1, State<S, C> s2);
    }
}
