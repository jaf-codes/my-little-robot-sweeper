using System;
using System.Collections.Generic;
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

        public Instructions(Coordinate startingLocation)
        {
            grid = new Grid(startingLocation);
            commands = new List<Command>();
            locationsCleaned = 1;

            currentLocation = startingLocation;
        }

        public void Load(Command command)
        {
            commands.Add(command);
        }

        public int Execute()
        {
            try
            {
                foreach (Command command in commands)
                {
                    locationsCleaned += grid.CleanAll(ref currentLocation, command);
                }
            }

            catch { }

            return locationsCleaned;
        }
    }
}
