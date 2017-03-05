using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Grid
    {
        private Dictionary<Coordinate, bool> coordinates;

        public Grid(Coordinate startingLocation)
            : this(startingLocation.Longitude, startingLocation.Latitude) { }

        public Grid(int longitude, int latitude)
        {
            coordinates = new Dictionary<Coordinate, bool>
            {
                {
                    new Coordinate(){ Longitude = longitude, Latitude = latitude },
                    true
                }
            };
        }

        public Coordinate RetrieveNext(Coordinate location, Direction direction)
        {
            bool thisTile = coordinates[location];
            Coordinate nextLocation = Advance(location, direction);

            InitializeIfNecessary(nextLocation);

            return nextLocation;
        }

        private void InitializeIfNecessary(Coordinate nextLocation)
        {
            if (!coordinates.TryGetValue(nextLocation, out bool nextTile))
            {
                coordinates.Add(nextLocation, false);
            }
            else
            {
                nextTile = coordinates[nextLocation];
            }
        }

        public Coordinate Advance(Coordinate coordinate, Direction direction)
        {
            int longitude = coordinate.Longitude;
            int latitude = coordinate.Latitude;

            switch (direction)
            {
                case Direction.North:
                    latitude++;
                    break;
                case Direction.East:
                    longitude++;
                    break;
                case Direction.South:
                    latitude--;
                    break;
                case Direction.West:
                    longitude--;
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

        public int Clean(Coordinate location)
        {
            if (!coordinates[location])
            {
                coordinates[location] = true;
                return 1;
            }
            return 0;
        }
    }
}
