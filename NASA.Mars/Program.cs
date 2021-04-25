using NASA.Mars.Impl;
using NASA.Mars.Impl.Constraints;
using NASA.Mars.Impl.Parsers;
using NASA.Mars.Impl.Sequencers;
using System;

namespace NASA.Mars
{
    class Program
    {
        static void Main(string[] args)
        {
            var positionParser = new PositionParser();
            var initialPosition = "[10 10 N]";
            var commonStartingPosition = new Position(positionParser, initialPosition);

            var rover0 = new Rover(commonStartingPosition, new SimpleCommandSequencer(), new SystemConstraint());
            rover0.Move("R1R3L2L1");
            Console.WriteLine($"{rover0}");

            var rover1 = new Rover(commonStartingPosition, new SimpleCommandSequencer(), new EcoSystemConstraint(40, 30));
            rover1.Move("R5L1L4R1");
            Console.WriteLine($"{rover1}");
        }
    }
}
