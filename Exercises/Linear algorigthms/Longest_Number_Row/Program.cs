using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Number_Row
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            if (numbers.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            int maxAmount = 0;
            int currentAmount = 0;
            int maxNumber = numbers[0];
            
            for (int i = 0; i<numbers.Count; i++)
            {
                currentAmount++;
                int currentNumber = numbers[i];
                if (currentNumber == numbers[i+1])
                {
                    
                    if (currentAmount > maxAmount)
                    {
                        maxAmount = currentAmount;
                        maxNumber = currentNumber;
                    }
                }
                else
                {
                    currentAmount = 0;
                }
            }
            for (int i = 0; i < maxAmount; i++)
            {
                Console.Write(maxAmount + " ");
            }
            Console.WriteLine();
        }
    }
}
