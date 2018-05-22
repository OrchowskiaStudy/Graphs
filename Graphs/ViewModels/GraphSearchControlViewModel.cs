using Graphs.Models.BL;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.ViewModels
{
    public class GraphSearchControlViewModel : ViewModelBase
    {
        private const string LIST_SEPARATOR = "⬌";
        private List<Vertex> Vertices = GraphContext.Instance.Vertices;
        private List<Edge> Edges = GraphContext.Instance.Edges;
        public bool IsConnected { get; set; }
        public List<Edge> CriticalEdges { get; set; }
        public string SearchOrder { get; private set; }

        public RelayCommand FindCriticalEdges => new RelayCommand((param) =>
        {
            CriticalEdgeFinder finder = new CriticalEdgeFinder(Vertices, Edges);
            IsConnected = finder.IsConntected(Edges);
            CriticalEdges = finder.Find();
            OnPropertyChanged(nameof(CriticalEdges));
            OnPropertyChanged(nameof(IsConnected));
        });

        public RelayCommand  RunDeepFirstSearch=> new RelayCommand((param) =>
        {
            DeepFirstSearch deepFirstSearch = new DeepFirstSearch(Vertices, Edges);
            SearchOrder = string.Join(LIST_SEPARATOR, deepFirstSearch.VisitAll().Select(x => x.Id));
            OnPropertyChanged(nameof(SearchOrder));            
        });
    }
}