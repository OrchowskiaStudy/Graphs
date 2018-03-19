using QuickGraph;
using QuickGraph.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Views.Models
{
    public class GraphView : BidirectionalGraph<VertexView, EdgeView>
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

        public GraphView(bool allowParallelEdges, int vertexCapacity, int edgeCapacity, IEqualityComparer<VertexView> vertexComparer) : base(allowParallelEdges, vertexCapacity, edgeCapacity, vertexComparer)
        {
        }
    }
}
