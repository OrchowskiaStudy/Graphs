using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using QuickGraph;
using System.Collections.Generic;

namespace Graphs.Views.Models
{
    public class GraphView : BidirectionalGraph<Vertex, Edge>
    {
        public GraphView()
        {
        }

        public GraphView(bool allowParallelEdges) : base(allowParallelEdges)
        {
        }

        public GraphView(bool allowParallelEdges, int vertexCapacity) : base(allowParallelEdges, vertexCapacity)
        {
        }

        public GraphView(bool allowParallelEdges, int vertexCapacity, int edgeCapacity) : base(allowParallelEdges, vertexCapacity, edgeCapacity)
        {
        }

        public GraphView(bool allowParallelEdges, int vertexCapacity, int edgeCapacity, IEqualityComparer<Vertex> vertexComparer) : base(allowParallelEdges, vertexCapacity, edgeCapacity, vertexComparer)
        {
        }
    }
}