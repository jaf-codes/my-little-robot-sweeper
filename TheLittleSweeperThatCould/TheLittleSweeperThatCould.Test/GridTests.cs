using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class GridTests
    {
        private Grid target;

        [TestInitialize]
        public void InitializeTest()
        {
            target = new Grid(TestCoordinates.Center);
        }

        [TestMethod]
        public void RetrieveNext_North_ExpectDirty()
        {
            Coordinate expected = TestCoordinates.NorthOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.North);
        }

        [TestMethod]
        public void RetrieveNext_East_ExpectDirty()
        {
            Coordinate expected = TestCoordinates.EastOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.East);
        }

        [TestMethod]
        public void RetrieveNext_South_ExpectDirty()
        {
            Coordinate expected = TestCoordinates.SouthOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.South);
        }

        [TestMethod]
        public void RetrieveNext_West_ExpectDirty()
        {
            Coordinate expected = TestCoordinates.WestOfCenter;
            RetrieveNext_StartAtCenter_NoneExist_Test(expected, Direction.West);
        }


        private void RetrieveNext_StartAtCenter_NoneExist_Test(Coordinate expected, Direction direction)
        {
            //Arrange
            Coordinate start = TestCoordinates.Center;
            int expectedTilesCleaned = 1;
            Command command = new Command()
            {
                Direction = direction,
                Distance = 1
            };

            //Act
            Coordinate actual = TestCoordinates.Center;
            int actualTilesCleaned = target.CleanAll(ref actual, command);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedTilesCleaned, actualTilesCleaned);
        }
    }
}
