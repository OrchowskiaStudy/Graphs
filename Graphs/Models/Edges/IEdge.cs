using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.Edges
{
    public interface IEdge
    {
        string Id { get; }
        int Weight { get; set; }
        string Name { get; set; }
    }
}
