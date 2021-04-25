using NASA.Mars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Impl
{
    public struct Command : ICommand
    {
        public string Direction { get; set; }
        public int Units { get; set; }
        public string CommandSequence { get; set; }

        public Command(string commandSequence, int units, string direction)
        {
            CommandSequence = commandSequence;
            Units = units;
            Direction = direction;
        }
    }
}
