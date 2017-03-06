using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class InstructionsTests
    {
        private Instructions target;

        [TestInitialize]
        public void InitializeTest()
        {
            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };

            target = new Instructions(startingLocation);
        }

        [TestMethod]
        public void Execute_NoCommands_CleanOnlyStartingTile()
        {
            //Arrange
            int expected = 1;

            Execute_Test(expected);
        }

        [TestMethod]
        public void Execute_OneCommand_Distance_1_CleanTwoTiles()
        {
            //Arrange
            Command command = new Command()
            {
                Distance = 1,
                Direction = Direction.North
            };
            target.Load(command);
            int expected = 2;

            Execute_Test(expected);
        }

        [TestMethod]
        public void Execute_TwoCommands_BothOutward_CleanThreeTiles()
        {
            //Arrange
            Command first = new Command()
            {
                Distance = 1,
                Direction = Direction.North
            };
            Command second = new Command()
            {
                Distance = 1,
                Direction = Direction.North
            };
            target.Load(first);
            target.Load(second);
            int expected = 3;

            Execute_Test(expected);
        }

        [TestMethod]
        public void Execute_TwoCommands_OutThenIn_CleanTwoTiles()
        {
            //Arrange
            Command first = new Command()
            {
                Distance = 1,
                Direction = Direction.North
            };
            Command second = new Command()
            {
                Distance = 1,
                Direction = Direction.South
            };
            target.Load(first);
            target.Load(second);
            int expected = 2;

            Execute_Test(expected);
        }

        private void Execute_Test(int expected)
        {
            //Act
            int actual = target.Execute();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore]
        public void Memory_Test()
        {
            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 10000,
                Latitude = 10000
            };


            target = new Instructions(startingLocation);
            int orders = 10000;
            while (orders > 0)
            {
                Command moveEast = new Command()
                {
                    Distance = 100000,
                    Direction = Direction.East
                };
                target.Load(moveEast);
                orders--;

                Command moveOneNorth = new Command()
                {
                    Distance = 1,
                    Direction = Direction.North
                };

                target.Load(moveOneNorth);
                orders--;

                Command moveWest = new Command()
                {
                    Distance = 100000,
                    Direction = Direction.West
                };

                target.Load(moveWest);
                orders--;
                target.Load(moveWest);
                orders--;

                target.Load(moveOneNorth);
                orders--;

                target.Load(moveEast);
                orders--;
            }
            int locations = target.Execute();

            Assert.Inconclusive();
        }
    }
}
