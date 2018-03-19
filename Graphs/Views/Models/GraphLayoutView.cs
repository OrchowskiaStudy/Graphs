using GraphSharp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Views.Models
{
    public class GraphLayoutView : GraphLayout<VertexView, EdgeView, GraphView>
    {
        public GraphLayoutView()
        {
            this.VisualEdgeMode = System.Windows.Media.EdgeMode.Aliased;
        }
    }
}
