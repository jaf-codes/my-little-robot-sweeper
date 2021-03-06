﻿using System;
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
    }
}
