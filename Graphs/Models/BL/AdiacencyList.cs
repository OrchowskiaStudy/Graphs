using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class AdiacencyList
    {
        private const string LIST_SEPARATOR = "⬌";
        public List<Vertex> Vertices { get; private set; }
        public List<Edge> Edges { get; private set; }

        public AdiacencyList(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public Dictionary<string,string> ToAdiacencyList()
        {
            return Vertices.ToDictionary(key => key.Id, value => GetAdjacencies(value));
        }

        private string GetAdjacencies(Vertex vertex)
        {
            var adjacencies = Edges.Where(e => e.Source == vertex || e.Target == vertex).Select(e => e.Target == vertex ? e.Source.Id : e.Target.Id);
            return String.Join(LIST_SEPARATOR, adjacencies);
        }
    }
}
