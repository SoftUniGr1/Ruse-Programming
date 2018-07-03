using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            double sum = 0;
            int count = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
                count++;
            }

            Console.WriteLine("Average: {0:0.00}; Sum: {1}", sum / count, sum);
        }
    }
}
