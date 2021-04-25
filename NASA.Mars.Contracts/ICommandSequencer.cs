using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Contracts
{
    public interface ICommandSequencer
    {
        List<ICommand> Sequence(string commands); // IList or ICollection<ICommand> for linked lists
    }
}
