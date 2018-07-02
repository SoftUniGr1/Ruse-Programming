using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Count_Row
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', ',').Select(int.Parse).ToArray();
            int currVal = nums[0];
            int maxVal = currVal;
            int currLength = 1;
            int maxLength = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (currVal == nums[i])
                {
                    currLength++;
                }
                else
                {
                    if (currLength > maxLength)
                    {
                        maxLength = currLength;
                        maxVal = currVal;
                    }
                    
                        currLength = 1;
                        currVal = nums[i];

                    
                }
                
            }

            Console.WriteLine("{0} - {1} times", maxVal, maxLength);
        }
    }
}
