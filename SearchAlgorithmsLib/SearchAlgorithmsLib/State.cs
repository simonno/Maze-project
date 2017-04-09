using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State<T>
    {
        public Cost cost; // cost to reach this state (set by a setter)
        public static class StatePool
        {
            private static HashSet<State<T>> pool = new HashSet<State<T>>();

            public static ref State<T> getState(ref T  state)
            {
                if (pool.(state.GetHashCode())
                {
                    return ref pool.;
                } else
                {
                    State<T> s = new State<T>(state);
                    pool.Add(s);
                    return ref s;
               
                }
            }
        }

        private T state
        {
           get { return state; }
           set { state = value; }
        }
        public State<T> cameFrom
        {
            set { cameFrom = value; }
            get { return cameFrom; }
        }

        private State(T state) // CTOR
        {
            this.state = state;
        }

        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return state.Equals(s.state);
        }

        public override int GetHashCode()
        {
            return state.GetHashCode();
        }

        public interface Cost : IComparable<Cost>
        {
            void AddCost(Cost c);
        }
    }
}
