using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Of_Meetings
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> meetings = new SortedDictionary<int, int>();
            int numberOfMeetings = 0;
            int[] nums = Console.ReadLine().Split(' ', ',').Select(int.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                numberOfMeetings = 0;
                for (int k = 0; k < nums.Length; k++)
                {
                    if (nums[i] == nums[k])
                    {
                        numberOfMeetings++;
                    }
                }
                if (!meetings.ContainsKey(nums[i]))
                {
                    meetings.Add(nums[i], numberOfMeetings);
                }
            }
            meetings.OrderBy(x => x.Key);
            foreach (var key in meetings)
            {
                Console.WriteLine("{0} - {1} times", key.Key, key.Value);
            }
        }
    }
}
