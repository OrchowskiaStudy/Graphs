using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class AdiacencyMatrix
    {
        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;

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

        private IEnumerable<int> FillRow(int p)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                var result = Edges.ToList().Where(edge => ((edge.Target.Equals(Vertices[i])) && (edge.Source.Equals(Vertices[p])))
                || (edge.Source.Equals(Vertices[i])) && (edge.Target.Equals(Vertices[p]))).Any() ? 1 : 0;
                yield return result;
            }
        }

        public void UpdateContext(List<List<int>> list)
        {
          
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i == j) continue;
                    if (list[i][j] == 1 && list[j][i] == 1)
                    {
                        Edges.Add(new Edge("", Vertices[i], Vertices[j]));
                    }
                }
            }
            GraphContext.Instance.NotifyObservers(null);
        }
    }
}
