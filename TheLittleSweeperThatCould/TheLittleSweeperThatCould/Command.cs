using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Command : IEquatable<Command>
    {
        public Direction Direction { get; set; }
        public int Distance { get; set; }

        public Command()
        {

        }

        public static Direction Translate(string direction)
        {
            switch (direction.ToLower())
            {
                case "n":
                    return Direction.North;
                case "e":
                    return Direction.East;
                case "s":
                    return Direction.South;
                case "w":
                    return Direction.West;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool Equals(Command other)
        {
            return (this.Direction == other.Direction &&
                    this.Distance == other.Distance);
        }
    }

    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }
}
