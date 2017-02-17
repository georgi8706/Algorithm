using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    [DebuggerDisplay("{Count}")]
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public IComparer<T> Comparer;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(T[] elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                HeapifyDown(0);
            }
            return min;
        }

        public T PeekMin()
        {
            var min = this.heap[0];
            return min;
        }

        public void Enqueue(T node)
        {
            this.heap.Add(node);
            HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            var smallest = i;

            if (left < this.heap.Count && Compare(left, smallest) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && Compare(right, smallest) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && Compare(i, parent) < 0)
            {
                T old = this.heap[i];
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;
                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private int Compare(int i, int j)
        {
            int compareRes;
            if (Comparer != null)
            {
                compareRes = Comparer.Compare(this.heap[i], this.heap[j]);
            }
            else
            {
                // Use default comparer
                compareRes = this.heap[i].CompareTo(this.heap[j]);
            }

            return compareRes;
        }
    }
}