using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Grid
    {
        private Sector currentSector;

        public Grid(Coordinate startingLocation, int maximumPossibleDistance = 0)
        {
            Sector.DetermineSectorSize(maximumPossibleDistance);
            currentSector = new Sector(startingLocation);
        }

        public int CleanAll(ref Coordinate location, Command command)
        {
            int locationsCleaned = 0;

            for (int i = 0; i < command.Distance; i++)
            {
                location = Coordinate.Advance(location, command.Direction);

                Coordinate locationSectorRoot = Sector.FindRoot(location);

                if (!currentSector.Root.Equals(locationSectorRoot))
                {
                    currentSector.Save();
                    currentSector = new Sector(location);
                }

                if (currentSector.Add(location))
                {
                    locationsCleaned++;
                }
            }

            return locationsCleaned;
        }



        


    }
}
