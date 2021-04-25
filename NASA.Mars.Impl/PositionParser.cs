using NASA.Mars.Contracts;
using System;
using System.Text.RegularExpressions;

namespace NASA.Mars.Impl
{
    public class PositionParser : IPositionParser
    {
        public IPosition Parse(string representation)
        {
            string pattern = @"\[(?<X>\d+) (?<Y>\d+) (?<Direction>N|E|S|W)\]";
            var match = Regex.Match(representation, pattern);
            if (match.Success)
            {
                int x = int.Parse(match.Groups["X"].Value);
                int y = int.Parse(match.Groups["Y"].Value);
                string direction = match.Groups["Direction"].Value;

                return new Position(x, y, direction);
            }

            throw new ArgumentException($"Position given is {representation}. Should be in form [X Y N|S|E|W]");
        }
    }
}
