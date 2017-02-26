using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLittleSweeperThatCould.Parsing;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class ParserTests
    {
        private Parser target;

        [TestInitialize]
        public void InitializeTest()
        {
            target = new Parser();
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseNumberOfCommands_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            int actual = target.ParseNumberOfCommands(text);
        }

        [TestMethod]
        public void ParseNumberOfCommands_ValidNumber_ReturnNumber()
        {
            //Arrange
            string text = "1";

            int expected = 1;

            //Act
            int actual = target.ParseNumberOfCommands(text);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseStartingLocation_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            Coordinate actual = target.ParseStartingLocation(text);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void ParseStartingLocation_OneGoodValue_ThrowException()
        {
            //Arrange
            string text = "1";

            //Act
            Coordinate actual = target.ParseStartingLocation(text);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseStartingLocation_OneGoodAndOneBadValue_ThrowException()
        {
            //Arrange
            string text = "1 A";

            //Act
            Coordinate actual = target.ParseStartingLocation(text);
        }

        [TestMethod]
        public void ParseStartingLocation_ValidValues_ReturnObject()
        {
            //Arrange
            string text = "1 1";

            Coordinate expected = new Coordinate() { X = 1, Y = 1 };

            //Act
            Coordinate actual = target.ParseStartingLocation(text);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ParseCommand_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            Command actual = target.ParseCommand(text);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ParseCommand_InvalidDirection_ThrowException()
        {
            //Arrange
            string text = "1";

            //Act
            Command actual = target.ParseCommand(text);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseCommand_InvalidDistance_ThrowException()
        {
            //Arrange
            string text = "E A";

            //Act
            Command actual = target.ParseCommand(text);
        }

        [TestMethod]
        public void ParseCommand_ValidValues_ReturnObject()
        {
            //Arrange
            string text = "E 1";

            Command expected = new Command() { Direction = Direction.East, Distance = 1 };

            //Act
            Command actual = target.ParseCommand(text);
        }
    }
}
