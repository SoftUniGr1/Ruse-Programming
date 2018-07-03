using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            List<string> newWords = new List<string>();
            newWords.AddRange(words);
            newWords.Sort();
            Console.WriteLine(String.Join(" ", newWords));
        }
    }
}
