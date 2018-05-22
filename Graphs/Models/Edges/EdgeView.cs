using Graphs.Models.BL;
using Graphs.Models.Vertices;
using Graphs.ViewModels;
using QuickGraph;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Graphs.Models.Edges
{
    public class Edge : Edge<Vertex>, IComparable<Edge>, INotifyPropertyChanged
    {
        public int Number { get; private set; }
        public string Id { get; private set; }
        public int Weight { get; set; } = 1;
        public WeightRef WeightRef { get; private set; }

        public Edge(string id, Vertex source, Vertex target) : base(source, target)
        {
            Number = GraphContext.EdgeCount;
            Id = Number.ToString();
            WeightRef = new WeightRef(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge edge)
            {
                return edge.Id == Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17 * 23 + Id.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(Edge other)
        {
            return Number.CompareTo(other.Number);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class WeightRef : ViewModelBase
    {
        private const string EMPTY_MASK_VALUE = "_";
        private const string DEFAULT_VALUE = "1";

        private Edge edge;

        public string Value
        {
            get { return edge.Weight.ToString(); }
            set
            {
                string val = value == EMPTY_MASK_VALUE ? DEFAULT_VALUE : value;
                edge.Weight = int.Parse(val);
                OnPropertyChanged(nameof(Value));
            }
        }

        public WeightRef(Edge edge)
        {
            this.edge = edge;
        }
    }
}