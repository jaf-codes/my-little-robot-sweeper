using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Grid
    {
        private HashSet<Coordinate> coordinates;

        public Grid(Coordinate startingLocation)
        {
            coordinates = new HashSet<Coordinate>
            {
                {
                    new Coordinate()
                    {
                        Longitude = startingLocation.Longitude,
                        Latitude = startingLocation.Latitude
                    }
                }
            };
        }

        public int CleanAll(ref Coordinate location, Command command)
        {
            int locationsCleaned = 0;

            for (int i = 0; i < command.Distance; i++)
            {
                location = Coordinate.Advance(location, command.Direction);

                if (coordinates.Add(location))
                {
                    locationsCleaned++;
                }
            }

            return locationsCleaned;
        }

        
    }
}
