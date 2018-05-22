using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class DeepFirstSearch
    {
        private List<Vertex> _vertices;
        private List<Edge> _edges;
        private List<Vertex> _result = new List<Vertex>();
        private List<VertexFamily> _families;

        public DeepFirstSearch(List<Vertex> vertices, List<Edge> edges)
        {
            _vertices = vertices;
            _edges = edges;
        }

        public List<Vertex> VisitAll()
        {
            _result.Clear();
            _families = new VertexFamilyFactory(_edges).CreateFamilies(_vertices).ToList();
            foreach (var family in _families)
            {
                VisitOne(family);
            }
            return _result;
        }

        private void VisitOne(VertexFamily family)
        {
            if (!family.Visited)
            {
                MarkFamilyAsVisited(family);
                foreach (var child in family.Childrens)
                {
                    VisitOne(ToFamily(child));
                }
            }
        }

        private void MarkFamilyAsVisited(VertexFamily family)
        {
            family.Visit();
            _result.Add(family.Parent);
        }

        private VertexFamily ToFamily(Vertex vertex)
        {
            return _families.FirstOrDefault(f => f.Parent == vertex);
        }
    }
}
