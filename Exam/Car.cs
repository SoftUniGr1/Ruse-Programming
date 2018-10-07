using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    class Car
    {
        private double amountFuel;
        private int horsePower;

        public Car(int horsePower, double amountFuel, Tyre typeTyre)
        {
            this.horsePower = horsePower;
            this.Tyre = typeTyre;
            this.FuelAmount = amountFuel;
        }

        protected double FuelAmount
        {
            get => this.amountFuel;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Out of fuel");
                }

                this.amountFuel = Math.Min(value, 160);
            }
        }

        public Tyre Tyre { get; private set; }

        public double Speed => (this.horsePower + this.Tyre.Degradation) / this.FuelAmount;

        public void ChangeTyres(Tyre freshTyre) => this.Tyre = freshTyre;

        public void Refuel(double fuelAmount) => this.FuelAmount += fuelAmount;

        public void DriveOneLap(double fuelConsumptionPerLap)
        {
            this.FuelAmount -= fuelConsumptionPerLap;
            this.Tyre.Degradate();
        }

    }
}