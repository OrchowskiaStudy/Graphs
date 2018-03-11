using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;

namespace Graphs.Models.Graphs
{
    public class Graph : IGraph
    {
        public IEnumerable<IVertex> Vertices { get; }
        public IEnumerable<IEdge> Edges { get; }

        public Graph()
        {
            Vertices = new HashSet<IVertex>();
            Edges = new HashSet<IEdge>();
        }
    }
}
