﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;

namespace mazeAdapter
{
    class MazeAdaptor : ISearchable<Position, int>
    {
        private Maze maze;

        public MazeAdaptor(Maze maze)
        {
            this.maze = maze;
        }

        public bool BetterDirection(State<Position, int> potentialCameFrom, State<Position, int> s)
        {
            if (s.cost.CompareTo(potentialCameFrom.cost
        }

        public List<State<Position, int>> GetAllPossibleStates(State<Position, int> s)
        {
            List<State<Position, int>> possibleStates = new List<State<Position, int>>();
            Position pos = s.StateValue;
            int x = pos.Col;
            int y = pos.Row;
            if (y + 1 < maze.Rows && maze[x,y + 1] == CellType.Free)
            {
                possibleStates.Add(State<Position, int>.StatePool.getState(new Position(x, y + 1)));
            }

            if (y - 1 >= 0 && maze[x, y - 1] == CellType.Free)
            {
                possibleStates.Add(State<Position, int>.StatePool.getState(new Position(x, y - 1)));
            }

            if (x + 1 < maze.Cols && maze[x + 1, y] == CellType.Free)
            {
                possibleStates.Add(State<Position, int>.StatePool.getState(new Position(x + 1, y)));
            }

            if (x - 1 >= 0 && maze[x - 1, y] == CellType.Free)
            {
                possibleStates.Add(State<Position, int>.StatePool.getState(new Position(x - 1, y)));
            }

            return possibleStates;
        }
        public State<Position, int> GetGoalState()
        {
            return State<Position, int>.StatePool.getState(maze.GoalPos);
        }

        public State<Position, int> GetInitialState()
        {
            return State<Position, int>.StatePool.getState(maze.InitialPos);
        }

        public class IntCost : State<Position, int>.ICost<int>
        {
            public int Value { get; set; }

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
