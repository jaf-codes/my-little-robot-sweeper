using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Coordinate
    {
        public int Longitude { get; set; }
        public int Latitude { get; set; }

        public Coordinate(string serializedCoordinate)
        {
            string[] coordinates = serializedCoordinate.Split(',');
            Longitude = Int32.Parse(coordinates[0]);
            Latitude = Int32.Parse(coordinates[1]);
        }

        public Coordinate()
        {

        }

        public static Coordinate Advance(Coordinate coordinate, Direction direction, int distance = 1)
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

        public override int GetHashCode()
        {
            return (Longitude * 53 + Latitude * 97);
        }

        public override bool Equals(object obj)
        {
            Coordinate coordinate = obj as Coordinate;
            if (coordinate == null)
            {
                return false;
            }
            return Equals(coordinate);
        }

        public bool Equals(Coordinate other)
        {
            return (this.Longitude == other.Longitude &&
                    this.Latitude == other.Latitude);
        }

        public override string ToString()
        {
            return string.Concat(Longitude, ",", Latitude, Environment.NewLine);
        }
    }
}
