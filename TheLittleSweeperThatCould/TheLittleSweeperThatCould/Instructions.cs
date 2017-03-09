using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Instructions
    {
        private Grid grid;
        private List<Command> commands;
        private int locationsCleaned;

        private Coordinate currentLocation;
        private int currentCommand;

        private int maximumPossibleDistance;

        public Instructions(Coordinate startingLocation)
        {
            commands = new List<Command>();
            locationsCleaned = 1;

            currentLocation = startingLocation;
            currentCommand = 0;

            maximumPossibleDistance = 0;
        }

        public void Load(Command command)
        {
            commands.Add(command);
            maximumPossibleDistance += command.Distance;
        }

        public int Execute()
        {
            grid = new Grid(currentLocation, maximumPossibleDistance);

            try
            {
                while (currentCommand < commands.Count)
                {
                    Command command = commands[currentCommand];
                    locationsCleaned += grid.CleanAll(ref currentLocation, command);
                    currentCommand++;
                }
            }

            catch { }

            return locationsCleaned;
        }
    }
}
