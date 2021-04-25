using NASA.Mars.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Contracts.Sequencers
{
    public interface ICommandSequencer
    {
        List<ICommand> Sequence(string commands);
    }
}
