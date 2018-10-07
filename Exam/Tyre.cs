using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    class Tyre
    {
        private double degr;
        private double degrMinCheck;

        protected Tyre(string name, double hardness, int degradationMinimum = 0)
        {
            this.Name = name;
            this.degrMinCheck = degradationMinimum;
            this.Hardness = hardness;
            this.Degradation = 100;
        }

        public string Name { get; }

        public double Hardness { get; }

        public double Degradation
        {
            get => this.degr;
            protected set
            {
                if (value < this.degrMinCheck)
                {
                    throw new ArgumentException("Blown Tyre");
                }

                this.degr = value;
            }
        }

        public virtual void Degradate() => this.Degradation -= this.Hardness;
        public Tyre CreateTyre(double hardness) => new HardTyre(hardness);
        public Tyre CreateTyre(double hardness, double grip) => new UltrasoftTyre(hardness, grip);
    }
}