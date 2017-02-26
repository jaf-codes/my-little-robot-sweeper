using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class CommandTests
    {
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Translate_Nothing_ThrowException()
        {
            //Arrange
            string text = string.Empty;

            //Act
            Direction actual = Command.Translate(text);
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
            Direction actual = Command.Translate(text);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_DifferentDistance_Test()
        {
            //Arrange
            Command first = new Command() { Direction = Direction.North, Distance = 2 };
            Command second = new Command() { Direction = Direction.North, Distance = 3 };

            bool expected = false;

            //Act
            bool firstEqualsSecond = first.Equals(second);
            bool secondEqualsFirst = second.Equals(first);

            //Assert
            Assert.AreEqual(expected, firstEqualsSecond);
            Assert.AreEqual(expected, secondEqualsFirst);
        }

        [TestMethod]
        public void Equals_DifferentDirection_Test()
        {
            //Arrange
            Command first = new Command() { Direction = Direction.North, Distance = 2 };
            Command second = new Command() { Direction = Direction.East, Distance = 2 };

            bool expected = false;

            //Act
            bool firstEqualsSecond = first.Equals(second);
            bool secondEqualsFirst = second.Equals(first);

            //Assert
            Assert.AreEqual(expected, firstEqualsSecond);
            Assert.AreEqual(expected, secondEqualsFirst);
        }

        [TestMethod]
        public void Equals_Same_Test()
        {
            //Arrange
            Command first = new Command() { Direction = Direction.North, Distance = 2 };
            Command second = new Command() { Direction = Direction.North, Distance = 2 };

            bool expected = true;

            //Act
            bool firstEqualsSecond = first.Equals(second);
            bool secondEqualsFirst = second.Equals(first);

            //Assert
            Assert.AreEqual(expected, firstEqualsSecond);
            Assert.AreEqual(expected, secondEqualsFirst);
        }
    }
}
