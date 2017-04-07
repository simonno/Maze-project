using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State<T>
    {
        public static class StatePool
        {
            private static HashSet<T> pool = new HashSet<T>();

            public static ref State<T> getState(T state)
            {
                if (pool.Contains(state))
                {
                    return ref pool(state);
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
            // the state represented by a string
        private double cost; // cost to reach this state (set by a setter)
        private State<T> cameFrom; // the state we came from to this state (setter)
        private State(T state) // CTOR
        {
            this.state = state;
        }

        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return state.Equals(s.state);
        }

        public static bool operator ==(State<T> s1, State<T> s2) // we overload Object's Equals method
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(State<T> s1, State<T> s2) // we overload Object's Equals method
        {
            return !s1.Equals(s2);
        }

        public override int GetHashCode()
        {
            return state.GetHashCode();
        }
    }
}
