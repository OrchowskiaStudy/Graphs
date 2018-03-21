using Graphs.Views.Commands;
using Graphs.Views.Models;
using GraphSharp.Controls;
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
        public GraphView GraphView { get; private set; } = new GraphView();

        public List<string> LayoutAlgorithmTypes { get { return _layoutAlgorithmTypes; } }

        private string _selectedLayoutType;
        public string SelectedLayoutType { get { return _selectedLayoutType; } set { _selectedLayoutType = value; OnPropertyChanged(nameof(SelectedLayoutType)); } }

        public GraphVisualisationViewModel()
        {
            SelectedLayoutType = LayoutAlgorithmTypes.FirstOrDefault();
            Vertices.Add(new VertexView("A", "aaa"));
            Vertices.Add(new VertexView("B", "bbb"));

            GraphView.AddVertexRange(Vertices);
        }

        public RelayCommand SelectEdge => new RelayCommand((param) => {
            if(param is EdgeControl control && control.Edge is EdgeView selectedEdge)
            {
                Edges.Remove(selectedEdge);
                GraphView.RemoveEdge(selectedEdge);
            }
        });

        public RelayCommand SelectVertex => new RelayCommand((param) =>
        {
            if (param is VertexControl control && control.Vertex is VertexView selectedVertex)
            {

                selectedVertex.IsSelected = !selectedVertex.IsSelected;
                selectedVertex.OnPropertyChanged(nameof(selectedVertex.IsSelected));

                var selectedVertices = Vertices.Where(v => v.IsSelected).ToList();

            if (selectedVertices.Contains(selectedVertex) && selectedVertices.Count == 2)
            {
                var secondVertex = selectedVertices.Where(vertex => vertex != selectedVertex).FirstOrDefault();
                    if (Edges.Where(i => (i.Source == selectedVertex && i.Target == secondVertex) || (i.Source == secondVertex && i.Target == selectedVertex)).Any()) { ClearVertexSelection(); return; }
                    var edge = new EdgeView(Guid.NewGuid().ToString(), selectedVertex, secondVertex);
                    Edges.Add(edge);
                    GraphView.AddEdge(edge);                    
                    ClearVertexSelection();
                }
            }
        });

        private void ClearVertexSelection()
        {
            Vertices.ToList().ForEach(vertex => { vertex.IsSelected = false; vertex.OnPropertyChanged(nameof(vertex.IsSelected)); });
        }
    }
}
