using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    class AggressiveDriver : Driver
    {
        public AggressiveDriver(string nameDriver, Car car) 
            : base(nameDriver, car, 2.7)
        {

        }
        public override double Speed => base.Speed * 1.3;       
    }
}