using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class PriorityQueue<T, TPriority> where T : IComparable<TPriority>
    {
        int totalSize;
        SortedDictionary<TPriority, State<T>> storage;

        public PriorityQueue()
        {
            this.storage = new SortedDictionary<TPriority, State<T>>();
            this.totalSize = 0;
        }

        public bool IsEmpty()
        {
            return (totalSize == 0);
        }

        public object First()
        {
            if (IsEmpty())
            {
                throw new Exception("priorityQueue is");
            }
            else
                foreach (Queue q in storage.Values)
                {
                    // we use a sorted dictionary
                    if (q.Count > 0)
                    {
                        totalSize--;
                        return q.Dequeue();
                    }
                }

            return null; // not supposed to reach here.
        }

        // same as above, except for peek.

        public object Peek()
        {
            if (IsEmpty())
                throw new Exception("Please check that priorityQueue is not empty before peeking");
            else
                foreach (Queue q in storage.Values)
                {
                    if (q.Count > 0)
                        return q.Peek();
                }

            Debug.Assert(false, "not supposed to reach here. problem with changing totalSize");

            return null; // not supposed to reach here.
        }

        public object Dequeue(int prio)
        {
            totalSize--;
            return storage[prio].Dequeue();
        }

        public void Enqueue(object item, int prio)
        {
            if (!storage.ContainsKey(prio))
            {
                storage.Add(prio, new Queue());
            }
            storage[prio].Enqueue(item);
            totalSize++;

        }
    }
}
