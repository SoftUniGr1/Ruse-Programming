using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Add_Method
{
    class Program
    {
        static void Add(List<int> nums, int numToCheck)
        {
            int check = 0;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[0] >= numToCheck)
                {
                    nums.Insert(0, numToCheck);
                    check++;
                    break;
                }
                if (nums[i]<= numToCheck && nums[i + 1] >= numToCheck)
                {
                    nums.Insert(i + 1, numToCheck);
                    check++;
                    break;
                }
            }
            if (check == 0)
            {
                nums.Add(numToCheck);
            }
            Console.WriteLine(String.Join(" ", nums));
        }

        static void Remove(List<int> nums, int numToCheck)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == numToCheck)
                {
                    nums.RemoveAt(i);
                }
            }
            Console.WriteLine(String.Join(" ", nums));
        }

        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int numToCheck = int.Parse(Console.ReadLine());
            if (nums.Contains(numToCheck))
            {
                Remove(nums, numToCheck);
            }
            else
            {
                Add(nums, numToCheck);
            }
        }
    }
}
