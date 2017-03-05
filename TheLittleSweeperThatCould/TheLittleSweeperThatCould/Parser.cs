using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould.Parsing
{
    public class Parser
    {
        public Parser()
        {

        }

        public int ParseNumberOfCommands(string text)
        {
            return Int32.Parse(text);
        }

        public Coordinate ParseStartingLocation(string text)
        {
            string[] coordinates = text.Split(' ');
            return new Coordinate()
            {
                Longitude = Int32.Parse(coordinates[0]),
                Latitude = Int32.Parse(coordinates[1])
            };
        }

        public Command ParseCommand(string text)
        {
            string[] commandParts = text.Split(' ');
            return new Command()
            {
                Direction = Command.Translate(commandParts[0]),
                Distance = Int32.Parse(commandParts[1])
            };
        }
    }
}
