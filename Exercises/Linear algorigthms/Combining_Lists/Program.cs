using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combining_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> combinedList = firstList;
            combinedList.AddRange(secondList);
            combinedList.Sort();
            Console.WriteLine(String.Join(" ", combinedList));
        }
    }
}
