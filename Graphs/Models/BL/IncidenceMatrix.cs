using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class IncidenceMatrix
    {
        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;

        public List<List<int>> ToMatrix()
        {
            List<List<int>> matrix = new List<List<int>>();
            for (int i = 0; i < Edges.Count; i++)
            {
                var row = FillRow(i).ToList();
                matrix.Add(row);
            }
            return matrix;
        }

        public void UpdateContext(List<List<int>> list)
        {
            Edges.Clear();
            foreach (var row in list)
            {
                var v1 = row.IndexOf(1);
                var v2 = row.LastIndexOf(1);
                if (v1 != v2 && v1 >= 0 && v2 >= 0)
                {
                    var vertexS = Vertices[v1];
                    var vertexT = Vertices[v2];
                    if(!Edges.Where(e=> e.Source == vertexS && e.Target == vertexT || e.Target == vertexS && e.Source == vertexT).Any())
                    Edges.Add(new Edge("", vertexS, vertexT));

                }
            }
            GraphContext.Instance.NotifyObservers(null);
        }

        private IEnumerable<int> FillRow(int e)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                var edge = Edges[e];
                var vertex = Vertices[i];
                var result = edge.Source == Vertices[i] || edge.Target == Vertices[i] ? 1 : 0;
                yield return result;
            }
        }
    }
}
