using System;
using System.Collections.Generic;
using System.IO;
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
            WipeOutTextFiles();
            int locationsCleaned = 0;
            try
            {
                int numberOfCommands = Parser.ParseNumberOfCommands(Console.ReadLine());
                Coordinate startingLocation = Parser.ParseStartingLocation(Console.ReadLine());

                Instructions instructions = new Instructions(startingLocation);

                for (int i = 0; i < numberOfCommands; i++)
                {
                    instructions.Load(Parser.ParseCommand(Console.ReadLine()));
                }

                locationsCleaned = instructions.Execute();
            }
            catch { }
            finally
            {
                Console.WriteLine("=> Cleaned: " + locationsCleaned);
            }
        }

        public static void WipeOutTextFiles()
        {
            foreach (string textFile in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt"))
            {
                File.Delete(textFile);
            }
        }
    }
}
