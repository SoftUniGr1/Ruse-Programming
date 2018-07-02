using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ', ',').Select(double.Parse).ToArray();
            List<double> list = new List<double>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    list.Add(arr[i]);
                }
            }
            arr = list.ToArray();
            Console.Write("{");
            Console.Write(String.Join(", ", arr));
            Console.WriteLine("}");
        }
    }
}
