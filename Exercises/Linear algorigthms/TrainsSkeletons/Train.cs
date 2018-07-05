using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    class Train
    {
        int number;
        string name;
        string type;
        int cars;

        public int Number
        {
            get => number;
            set => number = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public int Cars
        {
            get => cars;
            set => cars = value;
        }

        public Train(int number, string name, string type, int cars)
        {
            Number = number;
            Name = name;
            Type = type;
            Cars = cars;
        }

        public override string ToString()
        {
            return Number + " "+ Name + " " + Type + " " + Cars;
        }
    }
}
