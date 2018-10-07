using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    class UltrasoftTyre : Tyre
    {
        public UltrasoftTyre(double hardNess, double grip) 
            : base("Ultrasoft", hardNess, 30)
        {
            this.Grip = grip;
        }

        public double Grip
        {
            get;
        }

        public override void Degradate() => this.Degradation -= this.Hardness + this.Grip;
    }
}