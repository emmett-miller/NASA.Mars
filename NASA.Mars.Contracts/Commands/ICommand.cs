using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Contracts.Commands
{
    public interface ICommand
    {
        string CommandSequence { get; set; }
        string Direction { get; set; }
        int Units { get; set; }
    }
}
