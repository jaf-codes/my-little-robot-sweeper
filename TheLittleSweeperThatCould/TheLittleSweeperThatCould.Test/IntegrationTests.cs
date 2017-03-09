using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould.Test
{
    [TestCategory("IntegrationTests")]
    [TestClass]
    public class IntegrationTests
    {
        private Instructions target;

        [TestInitialize]
        public void InitializeTest()
        {
            Program.WipeOutTextFiles();

            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };

            target = new Instructions(startingLocation);
        }

        [TestCleanup]
        public void CleanData()
        {
            Program.WipeOutTextFiles();
        }

        [TestMethod]
        [Ignore]
        public void Random_Test()
        {
            //Arrange
            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };

            Random random = new Random(0);

            target = new Instructions(startingLocation);
            int orders = 10000;
            while (orders > 0)
            {
                Command randomCommand = new Command()
                {
                    Distance = random.Next(100000),
                    Direction = (Direction)random.Next(3)
                };
                target.Load(randomCommand);
                orders--;
            }
            int locations = target.Execute();

            Assert.Inconclusive();
        }

        [TestMethod]
        [Ignore]
        public void Memory_Test()
        {
            Coordinate startingLocation = new Coordinate()
            {
                Longitude = 0,
                Latitude = 0
            };


            target = new Instructions(startingLocation);
            int orders = 10000;
            while (orders > 0)
            {
                Command moveEast = new Command()
                {
                    Distance = 10000,
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
                    Distance = 10000,
                    Direction = Direction.West
                };

                target.Load(moveWest);
                orders--;

                target.Load(moveOneNorth);
                orders--;
            }

            int actual = target.Execute();

            Assert.Inconclusive();
        }
    }
}
