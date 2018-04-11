using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class VertexDegreeComputer
    {
        private const byte DEFAULT_DEGREE = 0;
        public List<Edge> Edges { get; private set; }
        public List<Vertex> Vertices { get; private set; }
        private Dictionary<Vertex, byte> _vertexToDegreeMap = new Dictionary<Vertex, byte>();
        public VertexDegreeComputer(List<Edge> edges, List<Vertex> vertices)
        {
            Edges = edges;
            Vertices = vertices;        
        }

        public Dictionary<Vertex,byte> Compute()
        {
            _vertexToDegreeMap.Clear();
            Vertices.ForEach(vertex => _vertexToDegreeMap.Add(vertex, DEFAULT_DEGREE));
            foreach(var edge in Edges)
            {
                _vertexToDegreeMap[edge.Source]++;
                _vertexToDegreeMap[edge.Target]++;
            }
            return _vertexToDegreeMap;
        }        
    }
}
