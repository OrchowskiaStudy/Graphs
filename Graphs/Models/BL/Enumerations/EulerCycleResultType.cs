using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL.Enumerations
{
    public enum EulerCycleResultType
    {
        Unknown = 0,
        Cycle = 1,
        Track = 2,
        NotExist = 3
    }
}
