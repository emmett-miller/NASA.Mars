using NASA.Mars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Impl
{
    public class EcoSystemConstraint : IConstraint
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
