using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Coordinate
    {
        public int Longitude;
        public int Latitude;

        public override int GetHashCode()
        {
            return (Longitude * 53 + Latitude* 97);
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
    }
}
