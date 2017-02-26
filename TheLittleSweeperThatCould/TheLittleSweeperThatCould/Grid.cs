using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Grid
    {
        private Coordinate[][] coordinates;

        public Grid(int initialSize)
        {
            coordinates = new Coordinate[initialSize][];

            for (int x = 0; x < initialSize; x++)
            {
                coordinates[x] = new Coordinate[initialSize];

                for (int y = 0; y < initialSize; y++)
                {
                    coordinates[x][y] = null;
                }
            }
        }

        public Coordinate Retrieve(int x, int y)
        {
            return coordinates[x][y];
        }

        public Coordinate RetrieveNext(Coordinate coordinate, Direction direction)
        {
            int x = coordinate.X;
            int y = coordinate.Y;

            switch (direction)
            {
                case Direction.North:
                    return Retrieve(x, y + 1);
                case Direction.East:
                    return Retrieve(x + 1, y);
                case Direction.South:
                    return Retrieve(x, y - 1);
                case Direction.West:
                    return Retrieve(x - 1, y);
                default:
                    throw new ArgumentOutOfRangeException("Neither flying nor transdimensional custodial robots are permitted for this application");
            }
        }

        public void Set(Coordinate coordinate)
        {
            coordinates[coordinate.X][coordinate.Y] = coordinate;
        }

        public int Clean(Coordinate coordinate)
        {
            int tilesCleaned = 0;
            Coordinate original = Retrieve(coordinate.X, coordinate.Y);
            if (original == null)
            {
                original = new Coordinate() { X = coordinate.X, Y = coordinate.Y, IsClean = false };
            }
            if (!original.IsClean)
            {
                original.IsClean = true;
                tilesCleaned++;
            }
            Set(original);
            return tilesCleaned;
        }
    }
}
