using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urok_3_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (nums.Length == 2)
            {
                for (int i1 = 1; i1<=nums[0]; i1++)
                {
                    for (int i2 = 1; i2 <= nums[1]; i2++)
                    {
                        Console.WriteLine("{0} {1}", i2, i1);
                    }
                }
            }
        }
    }
}
