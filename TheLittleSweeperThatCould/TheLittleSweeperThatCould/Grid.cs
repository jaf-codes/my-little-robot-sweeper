using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Grid
    {
        private Dictionary<Coordinate, Tile> coordinates;

        public Grid(int longitude, int latitude)
        {
            coordinates = new Dictionary<Coordinate, Tile>
            {
                {
                    new Coordinate(){ Longitude = longitude, Latitude = latitude },
                    new Tile() { IsClean = true }
                }
            };
        }

        public Coordinate RetrieveNext(Coordinate location, Direction direction)
        {
            Tile thisTile = coordinates[location];
            Coordinate nextLocation = Advance(location, direction);

            InitializeIfNecessary(nextLocation);

            return nextLocation;
        }

        private void InitializeIfNecessary(Coordinate nextLocation)
        {
            if (!coordinates.TryGetValue(nextLocation, out Tile nextTile))
            {
                nextTile = new Tile()
                {
                    IsClean = false
                };

                coordinates.Add(nextLocation, nextTile);
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
            Tile tile = coordinates[location];
            int tilesCleaned = 0;
            if (!tile.IsClean)
            {
                tile.IsClean = true;
                tilesCleaned++;
            }
            return tilesCleaned;
        }
    }
}
