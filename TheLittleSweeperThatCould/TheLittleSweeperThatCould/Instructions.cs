using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLittleSweeperThatCould
{
    public class Instructions : IEquatable<Instructions>
    {
        private Command[] Commands;
        public Coordinate Start { get; set; }

        public Instructions(int size)
        {
            Commands = new Command[size];
        }

        public bool Equals(Instructions other)
        {
            return (this.Start.Equals(other.Start) &&
                    CompareInstructions(other));
        }

        private bool CompareInstructions(Instructions other)
        {
            int thisLength = Commands.Length;
            int otherLength = other.Commands.Length;

            if (thisLength != otherLength)
            {
                return false;
            }

            for (int i = 0; i < thisLength; i++)
            {
                if (!Commands[i].Equals(other.Commands[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
