using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    class Engine
    {
        private bool checkIfRunning;
        private RaceTower raceTower;

        public Engine()
        {
            checkIfRunning = false;
        }

        public void Run()
        {
            this.checkIfRunning = true;
            this.InitilizeRaceTower();

            while (this.checkIfRunning)
            {
                string command = Console.ReadLine();
                try
                {
                    this.InterpredCommand(command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (this.raceTower.IsRaceOver())
                {
                    Console.WriteLine(this.raceTower.GetWinner());
                    this.checkIfRunning = false;
                }
            }
        }

        private void InitilizeRaceTower()
        {
            int lapsNumber = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());
            this.raceTower = new RaceTower();
            this.raceTower.SetTrackInfo(lapsNumber, trackLength);
        }

        private void InterpredCommand(string command)
        {
            string collectedOutput = String.Empty;
            List<string> commandArgs = command.Split().ToList();
            string commandType = commandArgs[0];
            commandArgs.RemoveAt(0);

            switch (commandType)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandArgs);
                    break;
                case "CompleteLaps":
                    collectedOutput = this.raceTower.CompleteLaps(commandArgs);
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandArgs);
                    break;               
                case "Leaderboard":
                    collectedOutput = this.raceTower.GetLeaderboard();
                    break;
            }

            if (collectedOutput != string.Empty)
            {
                Console.WriteLine(collectedOutput);
            }
        }
    }
}