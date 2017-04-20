﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;

namespace ModelLib
{
    /// <summary>
    /// adapte the objects
    /// </summary>
    /// <seealso cref="SearchAlgorithmsLib.ISearchable{MazeLib.Position, System.Int32}" />
    class ObjectAdapter : ISearchable<Position, int>
    {
        /// <summary>
        /// The maze
        /// </summary>
        private Maze maze;
        /// <summary>
        /// The initialize state
        /// </summary>
        private State<Position, int> init;
        /// <summary>
        /// The goal state
        /// </summary>
        private State<Position, int> goal;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAdapter"/> class.
        /// </summary>
        /// <param name="maze">The maze.</param>
        public ObjectAdapter(Maze maze)
        {
            this.maze = maze;

            init = State<Position, int>.StatePool.GetState(maze.InitialPos);
            init.cost = new IntCost() { Value = 0 };
            init.CameFrom = null; 

            goal = State<Position, int>.StatePool.GetState(maze.GoalPos);
        }

        /// <summary>
        /// Betters the direction.
        /// </summary>
        /// <param name="potentialCameFrom">The potential came from.</param>
        /// <param name="s">The State.</param>
        /// <returns>bool if there is better direction</returns>
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

        /// <summary>
        /// Gets all possible states.
        /// </summary>
        /// <param name="s">The s parameter is the state which we want to get his possible states for continue the sreach.</param>
        /// <returns>
        /// list of the possible states - the successors of s.
        /// </returns>
        public List<State<Position, int>> GetAllPossibleStates(State<Position, int> s)
        {
            List<State<Position, int>> possibleStates = new List<State<Position, int>>();
            Position pos = s.StateValue;
            int x = pos.Row;
            int y = pos.Col;
            if (y + 1 < maze.Cols && maze[x, y + 1] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.GetState(new Position(x, y + 1));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            if (y - 1 >= 0 && maze[x, y - 1] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.GetState(new Position(x, y - 1));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            if (x + 1 < maze.Rows && maze[x + 1, y] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.GetState(new Position(x + 1, y));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            if (x - 1 >= 0 && maze[x - 1, y] == CellType.Free)
            {
                State<Position, int> s2 = State<Position, int>.StatePool.GetState(new Position(x - 1, y));
                s2.cost = new IntCost()
                {
                    Value = 1
                };
                possibleStates.Add(s2);
            }

            return possibleStates;
        }
        /// <summary>
        /// Gets the state of the goal.
        /// </summary>
        /// <returns>
        /// the goal state of the sreach problem.
        /// </returns>
        public State<Position, int> GetGoalState()
        {
            return goal;
        }

        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <returns>
        /// the initial state of the sreach problem.
        /// </returns>
        public State<Position, int> GetInitialState()
        { 
            return init;
        }

        /// <summary>
        /// compute the cost direction
        /// </summary>
        /// <seealso cref="SearchAlgorithmsLib.State{MazeLib.Position, System.Int32}.ICost{System.Int32}" />
        public class IntCost : State<Position, int>.ICost<int>
        {
            /// <summary>
            /// The value of the cost
            /// </summary>
            private int value;
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value of the cost.
            /// </value>
            public int Value {
                get { return value; }
                set { this.value = value; }
            }

            /// <summary>
            /// Adds a cost to the current cost.
            /// </summary>
            /// <param name="c">The c is the cost we want to add.</param>
            public void AddCost(State<Position, int>.ICost<int> c)
            {
                Value += c.Value;
            }
            /// <summary>
            /// Compares the current instance with another object of the 
            /// same type and returns an integer that indicates whether the 
            /// current instance precedes, follows, or occurs in the same position 
            /// in the sort order as the other object.
            /// </summary>
            /// <param name="other">An object to compare with this instance.</param>
            /// <returns>
            /// A value that indicates the relative order of the objects 
            /// being compared.
            /// </returns>
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
