using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class VertexFamilyFactory
    {
        private readonly List<Edge> _edges;

        public VertexFamilyFactory(List<Edge> edges)
        {
            _edges = edges;
        }

        public VertexFamily CreateFamily(Vertex parent)
        {
            return new VertexFamily(parent, _edges.Where(e => e.Target == parent || e.Source == parent).Select(e => e.Source == parent ? e.Target : e.Source));
        }

        public IEnumerable<VertexFamily> CreateFamilies(IEnumerable<Vertex> vertices)
        {
            return vertices.Select(v => CreateFamily(v));
        }
    }
}
