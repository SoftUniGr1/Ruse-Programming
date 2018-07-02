using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', ',').Select(int.Parse).ToArray();
            List<int> hello = new List<int>();
            int numberOfMeetings = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                numberOfMeetings = 0;
                for (int i1 = 0; i1 < nums.Length; i1++)
                {
                    if (nums[i] == nums[i1])
                    {
                        numberOfMeetings++;
                    }
                }
                if (numberOfMeetings == nums.Length/2 + 1)
                {
                    if (!hello.Contains(nums[i]))
                    {
                        hello.Add(nums[i]);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", hello));
            if (hello.Count == 0)
            {
                Console.WriteLine("The majorant does not exist.");
            }
        }
    }
}
