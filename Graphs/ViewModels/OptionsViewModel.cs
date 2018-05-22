using Graphs.Models.BL;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System.Collections.Generic;

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