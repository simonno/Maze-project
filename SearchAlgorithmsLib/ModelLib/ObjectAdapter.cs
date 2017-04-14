using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;

namespace ModelLib
{
    class ObjectAdapter : ISearchable<Position, int>
    {
        private Maze maze;
        private State<Position, int> init;
        private State<Position, int> goal;

        public ObjectAdapter(Maze maze)
        {
            this.maze = maze;

            init = State<Position, int>.StatePool.getState(maze.InitialPos);
            init.cost = new IntCost() { Value = 0 };
            init.CameFrom = null; 

            goal = State<Position, int>.StatePool.getState(maze.GoalPos);
        }

        public bool BetterDirection(State<Position, int> potentialCameFrom, State<Position, int> s)
        {
            State<Position, int>.ICost<int> c = potentialCameFrom.cost;
            State<Position, int>.ICost<int> c2 = new IntCost()
            {
                Value = 1
            };
            c.AddCost(c2);

            if (c.CompareTo(s.cost) == 1) { return true; }
            else return false;
        }

        public List<State<Position, int>> GetAllPossibleStates(State<Position, int> s)
        {
            List<State<Position, int>> possibleStates = new List<State<Position, int>>();
            Position pos = s.StateValue;
            int x = pos.Row;
            int y = pos.Col;
            if (y + 1 < maze.Cols && maze[x, y + 1] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.getState(new Position(x, y + 1));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            if (y - 1 >= 0 && maze[x, y - 1] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.getState(new Position(x, y - 1));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            if (x + 1 < maze.Rows && maze[x + 1, y] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.getState(new Position(x + 1, y));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            if (x - 1 >= 0 && maze[x - 1, y] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.getState(new Position(x - 1, y));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            return possibleStates;
        }
        public State<Position, int> GetGoalState()
        {
            return goal;
        }

        public State<Position, int> GetInitialState()
        { 
            return init;
        }

        public class IntCost : State<Position, int>.ICost<int>
        {
            private int value;
            public int Value {
                get { return value; }
                set { this.value = value; }
            }

            public void AddCost(State<Position, int>.ICost<int> c)
            {
                Value += c.Value;
            }
            public int CompareTo(State<Position, int>.ICost<int> other)
            {
                if (Value > other.Value) { return 1; }
                else if (Value < other.Value) { return -1; }
                return 0;
            }
        }

        //private List<Position> GetPossiblePosition(Position pos)
        //{
        //    int x = pos.Col;
        //    int y = pos.Row;
        //    if (y + 1 < maze.Rows)
        //    {
        //    }
        //}
    }
}
