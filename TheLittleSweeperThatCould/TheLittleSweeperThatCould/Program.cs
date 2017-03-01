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
        public static void Main(string[] args)
        {
            int locationsCleaned = 0;

            try
            {
                Parser parser = new Parser();
                int numberOfCommands = parser.ParseNumberOfCommands(Console.ReadLine());
                Coordinate location = parser.ParseStartingLocation(Console.ReadLine());
                Grid grid = new Grid(location.Longitude, location.Latitude);

                locationsCleaned++;

                while (numberOfCommands > 0)
                {
                    Command command = parser.ParseCommand(Console.ReadLine());

                    for (int i = command.Distance; i > 0; i--)
                    {
                        location = grid.RetrieveNext(location, command.Direction);
                        locationsCleaned += grid.Clean(location);
                        Console.WriteLine(string.Format("Lat: {0}; Long: {1}", location.Latitude, location.Longitude));
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
