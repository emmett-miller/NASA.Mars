using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Contracts
{
    public interface IConstraint
    {
        public int XMax { get; set; }
        public int YMax { get; set; }
    }
}
