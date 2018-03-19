using Graphs.Views.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ViewModels
{
    public class GraphVisualisationViewModel : ViewModelBase
    {
        private List<string> _layoutAlgorithmTypes = new List<string>()
        {
            "BoundedFR", "Circular", "CompoundFDP", "FR", "EfficientSugiyama", "ISOM", "KK", "LinLog", "Tree"
        };

        public ObservableCollection<VertexView> Vertices { get; private set; } = new ObservableCollection<VertexView>();
        public ObservableCollection<EdgeView> Edges { get; private set; } = new ObservableCollection<EdgeView>();
        public GraphView GraphView { get; private set; } = new GraphView(true);

        public List<string> LayoutAlgorithmTypes { get { return _layoutAlgorithmTypes; } }

        //private string _selectedLayoutType;
        public string SelectedLayoutType { get; set; }

        public GraphVisualisationViewModel()
        {
            Vertices.Add(new VertexView("A","aaa"));
            Vertices.Add(new VertexView("B", "bbb"));
            Vertices.Add(new VertexView("C", "ccc"));

            Edges.Add(new EdgeView("1", Vertices[0], Vertices[1]));
            //Edges.Add(new EdgeView("2", Vertices[1], Vertices[2]));

            GraphView.AddVertexRange(Vertices);
            GraphView.AddEdgeRange(Edges);

            SelectedLayoutType = "LinLog";
            OnPropertyChanged(nameof(GraphView));
        }
    }
}
