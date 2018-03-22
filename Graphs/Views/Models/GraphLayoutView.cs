using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using GraphSharp.Controls;

namespace Graphs.Views.Models
{
    public class GraphLayoutView : GraphLayout<Vertex, Edge, GraphView>
    {
        public GraphLayoutView()
        {
            this.VisualEdgeMode = System.Windows.Media.EdgeMode.Aliased;
        }
    }
}