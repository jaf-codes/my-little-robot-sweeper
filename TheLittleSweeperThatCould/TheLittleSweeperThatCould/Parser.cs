using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould.Parsing
{
    public static class Parser
    {
        public static int ParseNumberOfCommands(string text)
        {
            return Int32.Parse(text);
        }

        public static Coordinate ParseStartingLocation(string text)
        {
            string[] coordinates = text.Split(' ');
            return new Coordinate()
            {
                Longitude = Int16.Parse(coordinates[0]),
                Latitude = Int16.Parse(coordinates[1])
            };
        }

        public static Command ParseCommand(string text)
        {
            string[] commandParts = text.Split(' ');
            return new Command()
            {
                Direction = Translate(commandParts[0]),
                Distance = Int32.Parse(commandParts[1])
            };
        }

        public static Direction Translate(string direction)
        {
            switch (direction)
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
