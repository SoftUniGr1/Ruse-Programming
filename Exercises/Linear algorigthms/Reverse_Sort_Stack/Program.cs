using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Sort_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Stack<int> stack = new Stack<int>(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }
            
            Console.WriteLine(String.Join(" ", stack));
        }
    }
}
