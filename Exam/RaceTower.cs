namespace GRID
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.IO;
    using System.Text;
    using System.Linq;


    public class RaceTower
    {
        
        private Func<Driver, double> CheckDriversTotalTimeFunc = d => d.TotalTime;
        private IDictionary<string, Driver> racingDriversDic;
        private IList<Driver> driversDNFList;

        private int lapsNumber;
        private int trackLength;
        private int tracksCompleted;
        private int tracksLeft;

        

        public RaceTower()
        {
            this.racingDriversDic = new Dictionary<string, Driver>();
            this.driversDNFList = new List<Driver>();           
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {          
            this.lapsNumber = lapsNumber;
            this.trackLength = trackLength;
            this.tracksCompleted = 0;
            this.tracksLeft = lapsNumber;
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            try
            {
                string driverType = commandArgs[0];
                string name = commandArgs[1];
                int hp = int.Parse(commandArgs[2]);
                double fuelAmount = double.Parse(commandArgs[3]);

                Tyre tyre = this.GetTyre(commandArgs.Skip(4).ToList());
                Car car = new Car(hp, fuelAmount, tyre);
                Driver driver;
                if (driverType == "Aggressive")
                { 
                    driver = new AggressiveDriver(name, car);
                }
                if (driverType == "Endurance")
                {
                    driver = new AggressiveDriver(name, car);
                }
                else
                {
                    throw new ArgumentException();
                }
                this.racingDriversDic.Add(name, driver);
            }
            catch (Exception)
            {
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            if (!this.racingDriversDic.ContainsKey(commandArgs[1]))
            {
                return;
            }

            string reason = commandArgs[0];
            commandArgs.RemoveAt(0);

            MethodInfo boxMethod = this.GetType().GetMethod(reason, BindingFlags.Instance | BindingFlags.NonPublic);
            boxMethod.Invoke(this, new object[] { commandArgs });
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            StringBuilder sb = new StringBuilder();
            int currLapsNumber = int.Parse(commandArgs[0]);

            try
            {
                if (tracksCompleted + currLapsNumber > lapsNumber)
                {
                    throw new ArgumentException(string.Format("There is no time! On lap {0}.", this.tracksCompleted));
                }
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }

            for (int i = 0; i < currLapsNumber; i++)
            {
                IEnumerable<string> racingDriversNames = this.racingDriversDic.Keys.ToList();
                foreach (string driversName in racingDriversNames)
                {
                    this.racingDriversDic[driversName].ProgressOneLap(trackLength);
                    if (this.racingDriversDic[driversName].IsDNF())
                    {
                        this.driversDNFList.Insert(0, this.racingDriversDic[driversName]);
                        this.racingDriversDic.Remove(driversName);
                    }
                }

                tracksCompleted++;

                
            }

            return sb.ToString().Trim();
        }
        
        public bool IsRaceOver() => tracksCompleted == lapsNumber;

        public string GetLeaderboard()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Lap {0}/{1}", tracksCompleted, lapsNumber));
            int counter = 1;
            IEnumerable<Driver> allDriversOrdered = this.racingDriversDic.Values
                .OrderBy(this.CheckDriversTotalTimeFunc)
                .Concat(this.driversDNFList);

            foreach (Driver driver in allDriversOrdered)
            {
                sb.AppendLine($"{counter} {driver}");
                counter++;
            }

            return sb.ToString().Trim();
        }

        public string GetWinner()
        {
            Driver winner = this.racingDriversDic.Values.OrderBy(this.CheckDriversTotalTimeFunc).First();
            return string.Format("{0} wins the race for {1:f3} seconds.", winner.Name, winner.TotalTime);
        }

        private Tyre GetTyre(IList<string> tyreArgs)
        {
            string tyreType = tyreArgs[0];
            double tyreHardness = double.Parse(tyreArgs[1]);

            if (tyreType == "Hard")
            {
                Tyre curr = new HardTyre(tyreHardness);
                return curr;
            }
            else if (tyreType == "Ultrasoft")
            {
                double tyreGrip = double.Parse(tyreArgs[2]);
                Tyre curr = new UltrasoftTyre(tyreHardness, tyreGrip);
                return curr;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void Refuel(List<string> args)
        {
            string driverName = args[0];
            double fuelAmount = double.Parse(args[1]);
            this.racingDriversDic[driverName].GasRefuel(fuelAmount);
        }

        private void ChangeTyres(List<string> args)
        {
            string driversName = args[0];
            args.RemoveAt(0);
            this.racingDriversDic[driversName].TyresBoxes(this.GetTyre(args));
        }

       
    }
}