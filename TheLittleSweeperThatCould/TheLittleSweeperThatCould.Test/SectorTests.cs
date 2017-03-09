using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class SectorTests
    {
        private Sector target;

        [TestInitialize]
        public void InitializeTest()
        {
            target = new Sector(TestCoordinates.Center);
        }

        [TestMethod]
        public void Add_Center_ExpectFalse()
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = target.Add(TestCoordinates.Center);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_NotCenter_ExpectTrue()
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = target.Add(TestCoordinates.NorthOfCenter);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindRoot_00_SectorSize10_Expect00()
        {
            //Arrange
            Sector.SectorSize = 10;
            Coordinate subject = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };

            Coordinate expected = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };
            FindRootTest(subject, expected);
        }

        [TestMethod]
        public void FindRoot_010_SectorSize10_Expect01()
        {
            //Arrange
            Sector.SectorSize = 10;
            Coordinate subject = new Coordinate()
            {
                Longitude = 0,
                Latitude = 10
            };

            Coordinate expected = new Coordinate()
            {
                Longitude = 0,
                Latitude = 1
            };
            FindRootTest(subject, expected);
        }

        private static void FindRootTest(Coordinate subject, Coordinate expected)
        {
            //Act
            Coordinate actual = Sector.FindRoot(subject);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileName_PositiveNumbers_Test()
        {
            //Arrange
            Sector.SectorSize = 10;

            string expected = "0_0.txt";
            FileNameTest(expected);
        }

        [TestMethod]
        public void FileName_NegativeNumbers_Test()
        {
            //Arrange
            Sector.SectorSize = 10;

            target = new Sector(new Coordinate()
            {
                Longitude = -10,
                Latitude = -10
            });

            string expected = "-1_-1.txt";
            FileNameTest(expected);
        }

        private void FileNameTest(string expected)
        {
            //Act
            string actual = target.FileName;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
