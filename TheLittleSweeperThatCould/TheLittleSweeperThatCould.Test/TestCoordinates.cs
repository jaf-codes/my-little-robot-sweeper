using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould.Test
{
    public static class TestCoordinates
    {
        public static readonly Coordinate Center = new Coordinate()
        {
            Longitude = 0,
            Latitude = 0
        };

        public static readonly Coordinate NorthOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude,
            Latitude = Center.Latitude + 1
        };

        public static readonly Coordinate EastOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude + 1,
            Latitude = Center.Latitude
        };

        public static readonly Coordinate SouthOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude,
            Latitude = Center.Latitude - 1
        };

        public static readonly Coordinate WestOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude - 1,
            Latitude = Center.Latitude
        };
    }
}
