using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class CoordinateTests
    {
        [TestMethod]
        public void Advance_North()
        {
            Coordinate expected = TestCoordinates.NorthOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.North);
        }

        [TestMethod]
        public void Advance_East()
        {
            Coordinate expected = TestCoordinates.EastOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.East);
        }

        [TestMethod]
        public void Advance_South()
        {
            Coordinate expected = TestCoordinates.SouthOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.South);
        }

        [TestMethod]
        public void Advance_West()
        {
            Coordinate expected = TestCoordinates.WestOfCenter;
            Advance_StartAtCenter_Test(expected, Direction.West);
        }

        private void Advance_StartAtCenter_Test(Coordinate expected, Direction direction)
        {
            //Arrange
            Coordinate start = TestCoordinates.Center;

            //Act
            Coordinate actual = Coordinate.Advance(start, direction);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
