using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State<T> : IComparable<State<T>> where T : IComparable<T>
    {
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

        public int CompareTo(State<T> other)
        {
            return state.CompareTo(other.state);
        }
    }
}
