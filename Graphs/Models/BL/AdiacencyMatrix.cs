using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Models.BL
{
    public class AdiacencyMatrix
    {
        public List<Vertex> Vertices { get; private set; }
        public List<Edge> Edges { get; private set; }

        public AdiacencyMatrix(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public List<List<int>> ToMatrix()
        {
            List<List<int>> matrix = new List<List<int>>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                var row = FillRow(i).ToList();
                matrix.Add(row);
            }
            return matrix;
        }

        public void UpdateContext(List<List<int>> list)
        {
            GraphContext.ClearEdges();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i == j) continue;
                    if (list[i][j] == 1 && list[j][i] == 1)
                    {
                        var vertexT = Vertices[j];
                        var vertexS = Vertices[i];
                        if (!Edges.Where(e => e.Source == vertexS && e.Target == vertexT || e.Target == vertexS && e.Source == vertexT).Any())
                            Edges.Add(new Edge("", vertexS, vertexT));
                    }
                }
            }
            GraphContext.Instance.NotifyObservers(null);
        }

        private IEnumerable<int> FillRow(int p)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                yield return Edges.ToList().Where(edge => ((edge.Target.Equals(Vertices[i])) && (edge.Source.Equals(Vertices[p])))
                || (edge.Source.Equals(Vertices[i])) && (edge.Target.Equals(Vertices[p]))).Any() ? 1 : 0;
            }
        }
    }
}