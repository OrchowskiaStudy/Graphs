using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using Graphs.Views.Converters;
using Graphs.Views.Models;
using GraphSharp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Graphs.ViewModels
{
    public class GraphVisualisationViewModel : ViewModelBase, IObserver, IDisposable
    {
        private const string VERTEX_EXIST_ERROR_MESSAGE = "VertexAlreadyExists_error";

        private List<string> _layoutAlgorithmTypes = new List<string>()
        {
            "BoundedFR", "Circular", "CompoundFDP", "FR", "EfficientSugiyama", "ISOM", "KK", "LinLog", "Tree"
        };

        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;
        public GraphView GraphView { get; private set; } = new GraphView();

        public List<string> LayoutAlgorithmTypes { get { return _layoutAlgorithmTypes; } }

        public string VertexName { get; set; }

        private string _selectedLayoutType;
        public string SelectedLayoutType { get { return _selectedLayoutType; } set { _selectedLayoutType = value; OnPropertyChanged(nameof(SelectedLayoutType)); } }

        public GraphVisualisationViewModel()
        {
            GraphContext.Instance.Add(this);
            SelectedLayoutType = LayoutAlgorithmTypes[1];
            Notify();
        }

        public RelayCommand AddVertex => new RelayCommand((param) =>
        {
            if (string.IsNullOrWhiteSpace(VertexName)) return;
            if (Vertices.Where(v => v.Id == VertexName).Any())
            {
                MessageBox.Show(VERTEX_EXIST_ERROR_MESSAGE.Localize());
                return;
            }
            Random random = new Random();

            var vertex = new Vertex(VertexName, VertexName);

            Vertices.Add(vertex);
            GraphView.AddVertex(vertex);
            GraphContext.Instance.NotifyObservers(this);
            OnPropertyChanged(nameof(GraphView));
        });

        public RelayCommand SelectEdge => new RelayCommand((param) =>
        {
            if (param is EdgeControl control && control.Edge is Edge selectedEdge)
            {
                Edges.Remove(selectedEdge);
                GraphView.RemoveEdge(selectedEdge);
                GraphContext.Instance.NotifyObservers(this);
            }
        });

        public RelayCommand SelectVertex => new RelayCommand((param) =>
        {
            if (param is VertexControl control && control.Vertex is Vertex selectedVertex)
            {
                selectedVertex.IsSelected = !selectedVertex.IsSelected;
                selectedVertex.OnPropertyChanged(nameof(selectedVertex.IsSelected));

                var selectedVertices = Vertices.Where(v => v.IsSelected).ToList();

                if (selectedVertices.Contains(selectedVertex) && selectedVertices.Count == 2)
                {
                    var secondVertex = selectedVertices.Where(vertex => vertex != selectedVertex).FirstOrDefault();
                    if (Edges.Where(i => (i.Source == selectedVertex && i.Target == secondVertex) || (i.Source == secondVertex && i.Target == selectedVertex)).Any()) { ClearVertexSelection(); return; }
                    var edge = new Edge(Guid.NewGuid().ToString(), selectedVertex, secondVertex);
                    Edges.Add(edge);
                    GraphView.AddEdge(edge);
                    GraphContext.Instance.NotifyObservers(this);
                    ClearVertexSelection();
                }
            }
        });

        public RelayCommand RemoveVertex => new RelayCommand((param) =>
        {
            if (param is VertexControl control && control.Vertex is Vertex selectedVertex)
            {
                GraphView.RemoveVertex(selectedVertex);
                Vertices.Remove(selectedVertex);
                Edges.Where(i => (i.Source == selectedVertex || i.Target == selectedVertex)).ToList().ForEach(i => Edges.Remove(i));
                GraphContext.Instance.NotifyObservers(this);
            }
        });

        private void ClearVertexSelection()
        {
            Vertices.ToList().ForEach(vertex => { vertex.IsSelected = false; vertex.OnPropertyChanged(nameof(vertex.IsSelected)); });
        }

        public void Notify()
        {
            GraphView.Edges.ToList().ForEach(item => GraphView.RemoveEdge(item));
            GraphView.Vertices.ToList().ForEach(item => GraphView.RemoveVertex(item));
            GraphView.AddVertexRange(Vertices);
            GraphView.AddEdgeRange(Edges);
            OnPropertyChanged(nameof(GraphView));
        }

        public void Dispose()
        {
            GraphContext.Instance.Remove(this);
        }
    }
}