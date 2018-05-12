using Graphs.Models;
using Graphs.Models.BL;
using Graphs.Models.BL.Enumerations;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ViewModels
{
    public class GraphSearchControlViewModel : ViewModelBase
    {
        private List<Vertex> Vertices = GraphContext.Instance.Vertices;
        private List<Edge> Edges = GraphContext.Instance.Edges;
        public bool IsConnected { get; set; }
        public List<Edge> CriticalEdges { get; set; }

        public RelayCommand FindCriticalEdges => new RelayCommand((param) =>
        {
            CriticalEdgeFinder finder = new CriticalEdgeFinder(Vertices, Edges);
            IsConnected = finder.IsConntected(Edges);
            CriticalEdges = finder.Find();
            OnPropertyChanged(nameof(CriticalEdges));
            OnPropertyChanged(nameof(IsConnected));
        });
    }
}
