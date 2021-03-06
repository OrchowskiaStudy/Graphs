﻿using Graphs.Extensions;
using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using System.Collections.Generic;

namespace Graphs.ViewModels
{
    public class IncidenceMatrixInputViewModel : ViewModelBase, IObserver
    {
        public List<List<Node>> Matrix { get; set; }
        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;

        private IncidenceMatrix _incidenceMatrix;

        public IncidenceMatrixInputViewModel()
        {
            GraphContext.Instance.Add(this);
            _incidenceMatrix = new IncidenceMatrix(Vertices, Edges);
            Matrix = _incidenceMatrix.ToMatrix().ToReferenceMatrix();
            OnPropertyChanged(nameof(Matrix));
        }

        public void Notify()
        {
            Matrix = _incidenceMatrix.ToMatrix().ToReferenceMatrix();
            OnPropertyChanged(nameof(Matrix));
            OnPropertyChanged(nameof(Vertices));
            OnPropertyChanged(nameof(Edges));
        }

        public RelayCommand MatrixValueChanged => new RelayCommand((sender) =>
        {
            _incidenceMatrix.UpdateContext(Matrix.ToNoReferenceMatrix());
        });
    }
}