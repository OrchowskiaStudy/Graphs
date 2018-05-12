using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class CriticalEdgeFinder
    {
        private readonly List<Vertex> _vertices;
        private readonly List<Edge> _edges;

        public CriticalEdgeFinder(List<Vertex> vertices, List<Edge> edges)
        {
            _vertices = vertices;
            _edges = edges;
        }

        public List<Edge> Find()
        {
            var criticalEdges = new HashSet<Edge>();
            if (IsConntected(_edges))
                foreach (var edge in _edges)
                {
                    var copy = new List<Edge>(_edges);
                    copy.Remove(edge);
                    var s = IsConntected(copy);
                    System.Diagnostics.Debug.WriteLine("Is connected : " + s);
                    if (!IsConntected(copy))
                        criticalEdges.Add(edge);
                }
            return criticalEdges.ToList();
        }

        public bool IsConntected(List<Edge> edges = null)
        {
            var results = new HashSet<Edge>();
            var checkedEdges = new List<Edge>();
            var copy = new List<Edge>(edges);

            foreach (var edge in copy)
            {
                checkedEdges.Add(edge);

                var c = copy.Where(x => x != edge && (x.Source == edge.Source || x.Target == edge.Target || x.Source == edge.Target || x.Target == edge.Source)).ToList();

                if (!results.Any())
                {
                    c.ForEach(x => results.Add(x));
                }
                else
                {
                    var b = c.Where(i => results.Where(x => (x.Source == i.Source || x.Target == i.Target || x.Source == i.Target || x.Target == i.Source)).Any()).ToList();
                    b.ForEach(x => results.Add(x));
                }
            }
            VertexDegreeComputer computer = new VertexDegreeComputer(edges, _vertices);
            Dictionary<Vertex, byte> degrees = computer.Compute();
            return results.Count == edges.Count && !degrees.Values.Where(x => x == 0).Any();
        }
    }
}
