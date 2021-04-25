using NASA.Mars.Contracts.Constraints;
using NASA.Mars.Contracts.Sequencers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Contracts
{
    public interface IRover
    {
        IConstraint Constraint { get; set; }

        IPosition CurrentPosition { get; set; }

        ICommandSequencer CommandSequencer { get; set; }

        void SetPosition(int x, int y, string direction);

        void Move(string commands);
    }
}
