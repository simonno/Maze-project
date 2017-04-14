using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="C"></typeparam>
    public class State<S, C>
    {
        public ICost<C> cost; // cost to reach this StateValue (set by a setter)

        public static class StatePool
        {
            private static Dictionary<int, State<S, C>> pool = new Dictionary<int, State<S, C>>();

            public static  State<S, C> getState(S  state)
            {
                if (pool.ContainsKey(state.ToString().GetHashCode()))
                {
                    return pool[state.ToString().GetHashCode()];
                } else
                {
                    State<S, C> s = new State<S, C>(state);
                    pool[state.ToString().GetHashCode()] = s;
                    return pool[state.ToString().GetHashCode()];
               
                }
            }
        }
        private S stateValue;
        public S StateValue
        {
            get { return stateValue; }
            set { stateValue = value; }
        }

        private State<S, C> cameFrom;
        public State<S, C> CameFrom
        {
            set { cameFrom = value; }
            get { return cameFrom; }
        }

        private State(S state) // CTOR
        {
            StateValue = state;
            CameFrom = null;
        }


        public bool Equals(State<S, C> s) // we overload Object's Equals method
        {
            return StateValue.Equals(s.StateValue);
        }

        public override int GetHashCode()
        {
            return StateValue.ToString().GetHashCode();
        }

        public interface ICost<V> : IComparable<ICost<V>>
        {
            V Value { get; set; }

            void AddCost(ICost<V> c);
        }
    }
}
