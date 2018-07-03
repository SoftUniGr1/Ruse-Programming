using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Mod
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> numberMeeting = new SortedDictionary<int, int>();
            int[] nums = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!numberMeeting.ContainsKey(nums[i]))
                {
                    numberMeeting.Add(nums[i], 1);
                }
                else
                {
                    numberMeeting[nums[i]]++;
                }
            }            

            int highestKey = numberMeeting.Keys.First();
            int highestAmount = numberMeeting.Values.First();
            double sum = 0;
            int br = 0;
            foreach (var key in numberMeeting)
            {
                if (highestAmount == key.Value)
                {
                    br++;
                    sum += key.Key;
                }
            }
            if (br != 0)
            {
                Console.WriteLine(highestKey);
            }
            else
            {
                Console.WriteLine(sum / highestAmount);
            }
        }
    }
}
