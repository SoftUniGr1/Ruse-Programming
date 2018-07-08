using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSkeleton
{
    class Pair
    {
        public int First { get; set; }

        public int Last { get; set; }



        public Pair(int first, int last)

        {
            this.First = first;
            this.Last = last;
            //TODO: Add code

        }



        public override string ToString()

        {
            return this.First + " " + this.Last;
            //TODO: Add code

        }



        public int Difference()

        {
            return Math.Abs(this.First - this.Last);
            //TODO: Add code

        }
    }
}
