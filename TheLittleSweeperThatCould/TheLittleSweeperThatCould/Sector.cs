using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Sector
    {
        public Coordinate LowerLeft { get; private set; }
        public Coordinate UpperRight { get; private set; }

        public Sector(Coordinate startingLocation, int standardSectorSize)
        {
            
            int longitude = startingLocation.Longitude / standardSectorSize;
            int latitude = startingLocation.Latitude / standardSectorSize;

            int minimumLongitude = startingLocation.Longitude * longitude;
            int minimumLatitude = startingLocation.Latitude * latitude;
            LowerLeft = new Coordinate()
            {
                Longitude = minimumLongitude,
                Latitude = minimumLatitude
            };

            int maximumLongitude = minimumLongitude + standardSectorSize;
            int maximumLatitude = minimumLatitude + standardSectorSize;
            UpperRight = new Coordinate()
            {
                Longitude = maximumLongitude,
                Latitude = maximumLatitude
            };

        }
    }


}
