using Graphs.Extensions;
using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using System.Collections.Generic;

namespace Graphs.ViewModels
{
    public class AdiacencyMatrixInputViewModel : ViewModelBase, IObserver
    {
        public List<List<Node>> Matrix { get; set; }
        private AdiacencyMatrix _adiacencyMatrix;
        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;

        public AdiacencyMatrixInputViewModel()
        {
            GraphContext.Instance.Add(this);
            _adiacencyMatrix = new AdiacencyMatrix(Vertices, Edges);
            Matrix = _adiacencyMatrix.ToMatrix().ToReferenceMatrix();
            OnPropertyChanged(nameof(Matrix));
        }

        public void Notify()
        {
            Matrix = _adiacencyMatrix.ToMatrix().ToReferenceMatrix();
            OnPropertyChanged(nameof(Matrix));
            OnPropertyChanged(nameof(Vertices));
            OnPropertyChanged(nameof(Edges));
        }

        public RelayCommand MatrixValueChanged => new RelayCommand((sender) =>
        {
            _adiacencyMatrix.UpdateContext(Matrix.ToNoReferenceMatrix());
        });
    }
}