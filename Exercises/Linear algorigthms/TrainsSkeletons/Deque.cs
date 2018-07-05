using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class Deque<T> : IList<T>
    {
        private static int defaultCapacity = 16;

        public static Stack<T> stack = new Stack<T>();

        private readonly IList<T> list = new List<T>();

        public int Capacity
        {
            get; set;
        }
        public int Count
        {
            get; set;
        }

        public bool IsReadOnly => list.IsReadOnly;

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public Deque() : this(defaultCapacity)
        {
            Capacity = 16;
            //празен конструктор, задава капацитета на дека на стойността по подразбиране (16)

        }

        public Deque(int capacity)
        {
            this.Capacity = capacity;
            //създава дека с точно зададен капацитет

        }
        public Deque(IEnumerable<T> collection) : this(collection.Count())
        {
            foreach (var item in collection)
            {
                list.Add(item);
                Count++;
            }
            //създава дека с капацитет съответстващ на посочената колекция и прехвърля елементите от колекцията в дека

        }
        
        public void PrintStack()
        {
            foreach (var item in stack)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }

        public void AddFront(T item)
        {
            list.Insert(0, item);
            Count++;
            //добавя елемент отпред

        }

        public void AddBack(T item)
        {
            list.Add(item);
            Count++;
            //добавя елемент отзад

        }

        public T RemoveFront()
        {
            T item = list[0];
            stack.Push(item);
            list.RemoveAt(0);
            Count--;
            return item;

            //връща и премахва елемента отпред

        }

        public T RemoveBack()
        {
            T item = list[list.Count - 1];
            stack.Push(item);
            list.RemoveAt(list.Count - 1);
            Count--;
            return item;
            //връща и премахва елемента отзад

        }

        public T GetFront()
        {
            return list[0];
            //връща, без да премахва, елемента отпред

        }

        public T GetBack()
        {
            return list[list.Count - 1];
            //връща, без да премахва, елемента отзад

        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }
    }
}
