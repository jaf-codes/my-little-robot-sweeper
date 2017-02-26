using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLittleSweeperThatCould.Parsing;

namespace TheLittleSweeperThatCould
{
    public class Program
    {
        private const int gridSize = 200001;
        private const int offset = 100001;

        public static void Main(string[] args)
        {
            int locationsCleaned = 0;

            try
            {
                Grid grid = new Grid(gridSize);
                Parser parser = new Parser();
                int numberOfCommands = parser.ParseNumberOfCommands(Console.ReadLine());
                Coordinate location = parser.ParseStartingLocation(Console.ReadLine());

                locationsCleaned += grid.Clean(location);

                while (numberOfCommands > 0)
                {
                    Command command = parser.ParseCommand(Console.ReadLine());

                    for (int i = command.Distance; i > 0; i--)
                    {
                        location = grid.RetrieveNext(location, command.Direction);
                        locationsCleaned += grid.Clean(location);
                    }

                    numberOfCommands--;
                }
            }
            catch { }
            finally
            {
                Console.WriteLine("Cleaned: " + locationsCleaned);
            }

            Console.ReadKey();
        }
    }
}
