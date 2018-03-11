using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.Graphs
{
    public interface IGraph
    {
        IEnumerable<IVertex> Vertices { get; }
        IEnumerable<IEdge> Edges { get; }
    }
}
