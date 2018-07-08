using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSkeleton
{
    class CapacityList
    {
        private const int InitialCapacity = 2;
        private Pair[] items;
        private int startIndex = 0; 
        private int nextIndex = 0; 
        public CapacityList(int capacity = InitialCapacity)
        {
            this.items = new Pair[capacity];
        }
        public int Count
        {
            get;
            private set;
        }
        public Pair SumIntervalPairs()
        {           
            Pair sum = new Pair(0, 0);
            for (int i = startIndex; i < nextIndex; i++)
            {
                
                sum.First += items[i].First;
                sum.Last += items[i].Last;
            }           
            return sum;
            
        }
        public Pair Sum()
        {
            Pair sum = new Pair(0, 0);
            for (int i = 0; i < startIndex; i++)
            {
                
                sum.First += items[i].First;
                sum.Last += items[i].Last;
            }
            return sum;
            
        }
        public void Add(Pair item)
        {
            CheckCapacity();
            items[nextIndex] = item;
            nextIndex++;           
                    
        }
        private void CheckCapacity()
        {
            if (nextIndex == items.Length)
            {
                Pair check = SumIntervalPairs();
                items[startIndex] = check;
                startIndex++;
                nextIndex = startIndex;
            }           
        }
        public void PrintCurrentState()
        {
            for (int i = 0; i < nextIndex; i++)
            {
                Console.WriteLine(string.Join("\n", (object)items));
            }
            
        }
    }
}
