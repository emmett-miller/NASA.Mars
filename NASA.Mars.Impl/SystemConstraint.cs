using NASA.Mars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Impl
{
    public class SystemConstraint : IConstraint
    {
        public int XMax { get => int.MaxValue; set => _ = int.MaxValue; }
        public int YMax { get => int.MaxValue; set => _ = int.MaxValue; }
    }
}
