using Graphs.Views.Commands;
using Graphs.Views.Converters;
using Graphs.Views.Models;
using GraphSharp.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Graphs.ViewModels
{
    public class GraphVisualisationViewModel : ViewModelBase
    {
        private const string VERTEX_EXIST_ERROR_MESSAGE = "VertexAlreadyExists_error";
        private List<string> _layoutAlgorithmTypes = new List<string>()
        {
            "BoundedFR", "Circular", "CompoundFDP", "FR", "EfficientSugiyama", "ISOM", "KK", "LinLog", "Tree"
        };

        public ObservableCollection<VertexView> Vertices { get; private set; } = new ObservableCollection<VertexView>();
        public ObservableCollection<EdgeView> Edges { get; private set; } = new ObservableCollection<EdgeView>();
        public GraphView GraphView { get; private set; } = new GraphView();

        public List<string> LayoutAlgorithmTypes { get { return _layoutAlgorithmTypes; } }

        public string VertexName { get; set; }

        private string _selectedLayoutType;
        public string SelectedLayoutType { get { return _selectedLayoutType; } set { _selectedLayoutType = value; OnPropertyChanged(nameof(SelectedLayoutType)); } }

        public GraphVisualisationViewModel()
        {
            SelectedLayoutType = LayoutAlgorithmTypes.FirstOrDefault();
        }

        public RelayCommand AddVertex => new RelayCommand((param) =>
        {
            if (string.IsNullOrWhiteSpace(VertexName)) return;
            if (Vertices.Where(v => v.Id == VertexName).Any())
            {
                MessageBox.Show(VERTEX_EXIST_ERROR_MESSAGE.Localize());
                return;
            }
            var vertex = new VertexView(VertexName, VertexName);
            Vertices.Add(vertex);
            GraphView.AddVertex(vertex);
            OnPropertyChanged(nameof(GraphView));
        });


        public RelayCommand SelectEdge => new RelayCommand((param) =>
        {
            if (param is EdgeControl control && control.Edge is EdgeView selectedEdge)
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

        public RelayCommand RemoveVertex => new RelayCommand((param) =>
        {
            if (param is VertexControl control && control.Vertex is VertexView selectedVertex)
            {
                GraphView.RemoveVertex(selectedVertex);
                Vertices.Remove(selectedVertex);
                Edges.Where(i => (i.Source == selectedVertex || i.Target == selectedVertex)).ToList().ForEach(i => Edges.Remove(i));
            }
        });

        private void ClearVertexSelection()
        {
            Vertices.ToList().ForEach(vertex => { vertex.IsSelected = false; vertex.OnPropertyChanged(nameof(vertex.IsSelected)); });
        }
    }
}
