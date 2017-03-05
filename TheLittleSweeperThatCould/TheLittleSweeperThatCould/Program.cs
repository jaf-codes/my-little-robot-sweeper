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
                Coordinate startingLocation = parser.ParseStartingLocation(Console.ReadLine());

                Instructions instructions = new Instructions(startingLocation);

                for (int i = 0; i < numberOfCommands; i++)
                {
                    instructions.Load(parser.ParseCommand(Console.ReadLine()));
                }

                locationsCleaned = instructions.Execute();
            }
            catch { }
            finally
            {
                Console.WriteLine("=> Cleaned: " + locationsCleaned);
            }
        }
    }
}
