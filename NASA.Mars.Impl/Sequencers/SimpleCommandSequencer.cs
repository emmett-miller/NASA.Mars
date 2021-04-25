using NASA.Mars.Contracts;
using NASA.Mars.Contracts.Commands;
using NASA.Mars.Contracts.Sequencers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NASA.Mars.Impl.Sequencers
{
    public class SimpleCommandSequencer : ICommandSequencer
    {
        // L1R2..
        public List<ICommand> Sequence(string commands)
        {
            Contract.Requires(!string.IsNullOrEmpty(commands));

            var matches = Regex.Matches(commands, @"(?<command>(?<direction>L|R)(?<units>\d+))", RegexOptions.Singleline);
            var seq = new List<ICommand>();
            
            foreach(Match match in matches)
            {
                var command = match.Groups["command"].Value;
                var direction = match.Groups["direction"].Value;
                var amount = int.Parse(match.Groups["units"].Value);

                seq.Add(new Command(command, amount, direction));
            }

            return seq;            
        }
    }
}
