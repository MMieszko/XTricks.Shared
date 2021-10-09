using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace XTricks.Shared.Collections
{
    public class SinkStack<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int MaxSize { get; }

        private T[] _elements;

        public SinkStack(int count)
        {
            if (count <= 0)
                throw new InvalidOperationException("Cannot create stack which size is less or equal zero");

            _elements = new T[count];
            MaxSize = count;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _elements.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            if (Count == MaxSize)
            {
                var tempArray = new T[MaxSize];
                Array.Copy(_elements, 1, tempArray, 0, Count - 1);
                _elements = tempArray;
                _elements[Count - 1] = item;
            }
            else
            {
                _elements[Count] = item;
                Count++;
            }
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            var result = _elements[Count - 1];
            _elements[Count - 1] = default;

            Count--;
            return result;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            return _elements[Count - 1];
        }

        public T PeekPeek()
        {
            if (Count == 1) throw new InvalidOperationException("Stack is empty");
            return _elements[Count - 2];
        }

        public void Clear()
        {
            for (var i = 0; i < Count; i++)
                _elements[i] = default;
            Count = 0;
        }
    }
}
