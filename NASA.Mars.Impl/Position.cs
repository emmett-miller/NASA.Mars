using NASA.Mars.Contracts;
using NASA.Mars.Contracts.Parsers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Impl
{
    public class Position : IPosition
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; }

        public Position(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public Position(IPositionParser positionParser, string position) 
        {
            var pos = positionParser.Parse(position);
            X = pos.X;
            Y = pos.Y;
            Direction = pos.Direction;
        }

        public override string ToString()
        {
            return $"[{X} {Y} {Direction}]";
        }
    }
}
