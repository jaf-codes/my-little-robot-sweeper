using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsClean { get; set; }

        public bool Equals(Coordinate other)
        {
            return (this.X == other.X &&
                    this.Y == other.Y &&
                    this.IsClean == other.IsClean);
        }
    }
}
