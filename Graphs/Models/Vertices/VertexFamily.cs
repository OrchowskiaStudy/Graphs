using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.Vertices
{
    public class VertexFamily
    {
        public Vertex Parent { get; }
        public IEnumerable<Vertex> Childrens { get; }
        public bool Visited { get; private set; }

        public VertexFamily(Vertex parent, IEnumerable<Vertex> childrens)
        {
            Parent = parent;
            Childrens = childrens;
        }

        public void Visit()
        {
            Visited = true;
        }
    }
}
