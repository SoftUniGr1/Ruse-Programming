using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', ',').Select(int.Parse).ToArray();
            List<int> remove = arr.ToList();
            List<int> evenList = new List<int>();
            List<int> newList = new List<int>();
            List<int> oddList = new List<int>();
            int odd = 1;
            for (int i = 0; i < remove.Count; i++)
            {
                odd = 1;
                for (int i1 = i; i1 < arr.Length; i1++)
                {
                    if (remove[i] == remove[i1])
                    {
                        odd++;
                    }
                }                
                if (odd % 2 == 0)
                {
                    evenList.Add(arr[i]);                  
                }
                if (odd % 2 == 1)
                {
                    for (int i1 = 0; i1 < remove.Count; i++)
                    {
                        if (remove[i] == remove[i1])
                        {
                            remove.RemoveAt(i1);
                        }
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (evenList.Contains(arr[i]))
                {
                    newList.Add(arr[i]);
                }
            }
            Console.WriteLine(String.Join(" ", newList));
        }
    }
}
