using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    abstract class Driver
    {
        private double FuelConsumptionPerKm;

        protected Driver(string name, Car car, double FuelConsumptionPerKm)
        {
            
            this.DNF = string.Empty;

            this.Name = name;
            this.Car = car;
            this.FuelConsumptionPerKm = FuelConsumptionPerKm;
        }

        protected Car Car { get; }

        protected string DNF { get; set; }

        public string Name { get; }

        public double TotalTime { get; set; }

        public virtual double Speed => this.Car.Speed;

        public void TyresBoxes(Tyre newTyreCurr)
        {
            this.Car.ChangeTyres(newTyreCurr);
            this.TotalTime += 20;
        }

        public void GasRefuel(double fuelAmount)
        {
            this.Car.Refuel(fuelAmount);
            this.TotalTime += 20;
        }
       
        public bool IsDNF() => this.DNF != string.Empty;

        public void ProgressOneLap(double trackLength)
        {
            try
            {
                double lapTime = 60 / (trackLength / this.Speed);
                this.TotalTime += lapTime;
                this.Car.DriveOneLap(trackLength * this.FuelConsumptionPerKm);
            }
            catch (ArgumentException msg)
            {
                this.DNF = msg.Message;
                Console.WriteLine(DNF);
            }
        }

        public override string ToString()
        {
            if (this.IsDNF())
            {
                return $"{this.Name} {this.DNF }";
            }

            return $"{this.Name} {this.TotalTime:f3}";

        }

    }
}