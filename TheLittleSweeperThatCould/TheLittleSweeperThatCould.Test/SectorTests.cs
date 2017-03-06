using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class SectorTests
    {
        private Sector target;

        [TestMethod]
        public void Constructor_Test()
        {
            //Arrange
            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };

            int standardSectorSize = 1000;

            target = new Sector(startingLocation, standardSectorSize);

            Coordinate expectedLowerLeft = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };

            Coordinate expectedUpperRight = new Coordinate()
            {
                Longitude = 1000,
                Latitude = 1000
            };

            //Act
            Coordinate actualLowerLeft = target.LowerLeft;
            Coordinate actualUpperRight = target.UpperRight;

            //Assert
            Assert.AreEqual(expectedLowerLeft, actualLowerLeft);
            Assert.AreEqual(expectedUpperRight, actualUpperRight);
        }

        [TestMethod]
        public void Constructor_2000_1000_Test()
        {
            //Arrange
            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 1000,
                Latitude = 0
            };

            int standardSectorSize = 1000;

            target = new Sector(startingLocation, standardSectorSize);

            Coordinate expectedLowerLeft = new Coordinate()
            {
                Longitude = 1000,
                Latitude = 0
            };

            Coordinate expectedUpperRight = new Coordinate()
            {
                Longitude = 2000,
                Latitude = 1000
            };

            //Act
            Coordinate actualLowerLeft = target.LowerLeft;
            Coordinate actualUpperRight = target.UpperRight;

            //Assert
            Assert.AreEqual(expectedLowerLeft, actualLowerLeft);
            Assert.AreEqual(expectedUpperRight, actualUpperRight);
        }
    }
}
