using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLittleSweeperThatCould.Parsing;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class ParserTests
    {
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Translate_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            Direction actual = Parser.Translate(text);
        }

        [TestMethod]
        public void Translate_N_North()
        {
            TestTranslation("N", Direction.North);
        }

        [TestMethod]
        public void Translate_E_East()
        {
            TestTranslation("E", Direction.East);
        }

        [TestMethod]
        public void Translate_S_South()
        {
            TestTranslation("S", Direction.South);
        }

        [TestMethod]
        public void Translate_W_West()
        {
            TestTranslation("W", Direction.West);
        }

        private static void TestTranslation(string text, Direction expected)
        {
            //Act
            Direction actual = Parser.Translate(text);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseNumberOfCommands_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            int actual = Parser.ParseNumberOfCommands(text);
        }

        [TestMethod]
        public void ParseNumberOfCommands_ValidNumber_ReturnNumber()
        {
            //Arrange
            string text = "1";

            int expected = 1;

            //Act
            int actual = Parser.ParseNumberOfCommands(text);

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
            Coordinate actual = Parser.ParseStartingLocation(text);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void ParseStartingLocation_OneGoodValue_ThrowException()
        {
            //Arrange
            string text = "1";

            //Act
            Coordinate actual = Parser.ParseStartingLocation(text);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseStartingLocation_OneGoodAndOneBadValue_ThrowException()
        {
            //Arrange
            string text = "1 A";

            //Act
            Coordinate actual = Parser.ParseStartingLocation(text);
        }

        [TestMethod]
        public void ParseStartingLocation_ValidValues_ReturnObject()
        {
            //Arrange
            string text = "1 1";

            Coordinate expected = new Coordinate() { Longitude = 1, Latitude = 1 };

            //Act
            Coordinate actual = Parser.ParseStartingLocation(text);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ParseCommand_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            Command actual = Parser.ParseCommand(text);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ParseCommand_InvalidDirection_ThrowException()
        {
            //Arrange
            string text = "1";

            //Act
            Command actual = Parser.ParseCommand(text);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseCommand_InvalidDistance_ThrowException()
        {
            //Arrange
            string text = "E A";

            //Act
            Command actual = Parser.ParseCommand(text);
        }

        [TestMethod]
        public void ParseCommand_ValidValues_ReturnObject()
        {
            //Arrange
            string text = "E 1";

            Command expected = new Command() { Direction = Direction.East, Distance = 1 };

            //Act
            Command actual = Parser.ParseCommand(text);
        }
    }
}
