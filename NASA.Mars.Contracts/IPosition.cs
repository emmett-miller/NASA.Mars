using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Contracts
{
    public interface IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
    }
}
