using Graphs.Models.BL;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ViewModels
{
    public class OptionsViewModel : ViewModelBase
    {
        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;

        public OptionsViewModel()
        {
        }
    }
}
