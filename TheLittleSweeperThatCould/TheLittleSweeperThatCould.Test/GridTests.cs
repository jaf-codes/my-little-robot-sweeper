using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class GridTests
    {
        private Grid target;

        private static Coordinate Center = new Coordinate()
        {
            Longitude = 1,
            Latitude = 1
        };

        private static Coordinate NorthOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude,
            Latitude = Center.Latitude + 1
        };

        private static Coordinate EastOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude + 1,
            Latitude = Center.Latitude
        };

        private static Coordinate SouthOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude,
            Latitude = Center.Latitude - 1
        };

        private static Coordinate WestOfCenter = new Coordinate()
        {
            Longitude = Center.Longitude - 1,
            Latitude = Center.Latitude
        };

        [TestInitialize]
        public void InitializeTest()
        {
            target = new Grid(Center.Longitude, Center.Latitude);
        }

        [TestMethod]
        public void RetrieveNext_North_ExpectDirty()
        {
            Coordinate expected = NorthOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.North);
        }

        [TestMethod]
        public void RetrieveNext_East_ExpectDirty()
        {
            Coordinate expected = EastOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.East);
        }

        [TestMethod]
        public void RetrieveNext_South_ExpectDirty()
        {
            Coordinate expected = SouthOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.South);
        }

        [TestMethod]
        public void RetrieveNext_West_ExpectDirty()
        {
            Coordinate expected = WestOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.West);
        }


        private void RetrieveNext_StartAtCenter_NoneExist_Test(Coordinate expected, Direction direction)
        {
            //Arrange
            Coordinate start = Center;
            int expectedTilesCleaned = 1;

            //Act
            Coordinate actual = target.RetrieveNext(start, direction);
            int actualTilesCleaned = target.Clean(actual);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedTilesCleaned, actualTilesCleaned);
        }

        [TestMethod]
        public void Advance_North()
        {
            Coordinate expected = NorthOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.North);
        }

        [TestMethod]
        public void Advance_East()
        {
            Coordinate expected = EastOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.East);
        }

        [TestMethod]
        public void Advance_South()
        {
            Coordinate expected = SouthOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.South);
        }

        [TestMethod]
        public void Advance_West()
        {
            Coordinate expected = WestOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.West);
        }

        private void Advance_StartAtCenter_Test(Coordinate expected, Direction direction)
        {
            //Arrange
            Coordinate start = Center;

            //Act
            Coordinate actual = target.Advance(start, direction);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clean_Dirty_ExpectCleaned()
        {
            //Arrange
            Coordinate next = target.RetrieveNext(Center, Direction.North);
            int expected = 1;

            //Act
            int actual = target.Clean(NorthOfCenter);

            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clean_AlreadyClean_ExpectNoTilesCleaned()
        {
            //Arrange
            int expected = 0;

            //Act
            int actual = target.Clean(Center);

            //Arrange
            Assert.AreEqual(expected, actual);
        }
    }
}
