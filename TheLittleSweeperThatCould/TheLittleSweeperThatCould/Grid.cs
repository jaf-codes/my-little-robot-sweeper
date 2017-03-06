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
            : this(startingLocation.Longitude, startingLocation.Latitude) { }

        public Grid(int longitude, int latitude)
        {
            coordinates = new HashSet<Coordinate>
            {
                {
                    new Coordinate(){ Longitude = longitude, Latitude = latitude }
                }
            };
        }

        public int CleanAll(ref Coordinate location, Command command)
        {
            int locationsCleaned = 0;

            for (int i = 0; i < command.Distance; i++)
            {
                location = Advance(location, command.Direction);

                if (coordinates.Add(location))
                {
                    locationsCleaned++;
                }
            }

            return locationsCleaned;
        }

        public Coordinate Advance(Coordinate coordinate, Direction direction, int distance = 1)
        {
            int longitude = coordinate.Longitude;
            int latitude = coordinate.Latitude;

            switch (direction)
            {
                case Direction.North:
                    latitude = latitude + distance;
                    break;
                case Direction.East:
                    longitude = longitude + distance;
                    break;
                case Direction.South:
                    latitude = latitude - distance;
                    break;
                case Direction.West:
                    longitude = longitude - distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Neither flying nor transdimensional custodial robots are permitted for this application");
            }

            return new Coordinate()
            {
                Longitude = longitude,
                Latitude = latitude
            };

        }
    }
}
