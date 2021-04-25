using NASA.Mars.Contracts;
using NASA.Mars.Contracts.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Impl.Constraints
{
    public struct EcoSystemConstraint : IConstraint
    {
        public int XMax { get; set; }
        public int YMax { get; set; }

        public EcoSystemConstraint(int xMax, int yMax)
        {
            XMax = xMax;
            YMax = yMax;
        }

    }
}
