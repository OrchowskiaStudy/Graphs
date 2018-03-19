using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Views.Models
{
    public class EdgeView : Edge<VertexView>
    {
        public string Id { get; set; }

        public EdgeView(string id,VertexView source, VertexView target) : base(source, target)
        {
            Id = id;
        }
    }
}
