using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Sector
    {
        public static int SectorSize { get; set; }

        private HashSet<Coordinate> coordinates;

        public Coordinate Root { get; private set; }

        public string FileName
        {
            get
            {
                return string.Concat(Root.Longitude, "_", Root.Latitude, ".txt");
            }
        }

        public Sector(Coordinate coordinate)
        {
            Root = FindRoot(coordinate);

            coordinates = new HashSet<Coordinate>();

            if (File.Exists(FileName))
            {
                Load();
            }

            Add(coordinate);
        }

        public static Coordinate FindRoot(Coordinate coordinate)
        {
            return new Coordinate()
            {
                Longitude = FindInterval(coordinate.Longitude),
                Latitude = FindInterval(coordinate.Latitude)
            };
        }

        private static int FindInterval(int position)
        {
            int interval = (position / SectorSize);
            return interval;
        }

        public static void DetermineSectorSize(int totalPossibleCommands)
        {
            if (totalPossibleCommands < 23000000)
            {
                SectorSize = 300000;
            }
            else
            {
                SectorSize = 1000;
            }
        }

        public bool Add(Coordinate coordinate)
        {
            return coordinates.Add(coordinate);
        }

        public void Load()
        {
            using (StreamReader reader = File.OpenText(FileName))
            {
                while (reader.Peek() > 0)
                {
                    string serializedCoordinate = reader.ReadLine();
                    coordinates.Add(new Coordinate(serializedCoordinate));
                }
            }
        }

        public void Save()
        {
            using (TextWriter writer = new StreamWriter(FileName, false, Encoding.UTF8, 65536))
            {
                foreach (Coordinate coordinate in coordinates)
                {
                    writer.Write(coordinate.ToString());
                }
            }
        }




    }
}
