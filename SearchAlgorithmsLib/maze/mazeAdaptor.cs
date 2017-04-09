using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;

namespace mazeAdapter
{
    class MazeAdaptor : ISearchable<Maze>
    {
        public List<State<Maze>> getAllPossibleStates(State<Maze> s)
        {
            throw new NotImplementedException();
        }

        public State<Maze> getGoalState()
        {
            throw new NotImplementedException();
        }

        public State<Maze> getInitialState()
        {
            throw new NotImplementedException();
        }
    }
}
