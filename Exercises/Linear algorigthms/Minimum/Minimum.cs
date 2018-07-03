using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urok_3_Exercise
{
    class Minimum
    {
        public Minimum(int[] numbers)
        {
            int smallestNum = int.MaxValue;
            if (numbers.Length == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (smallestNum > numbers[i])
                {
                    smallestNum = numbers[i];
                }
            }
            Console.WriteLine("Smallest number is: {0}", smallestNum);
        }
    }
}
