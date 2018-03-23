using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
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
    public class AdiacencyListInputViewModel : ViewModelBase, IObserver
    {
        public Dictionary<string, string> AdiacencyList { get; set; } = new Dictionary<string, string>();
        public List<Vertex> Vertices { get; private set; } = GraphContext.Instance.Vertices;
        public List<Edge> Edges { get; private set; } = GraphContext.Instance.Edges;
        public Vertex SelectedC1 { get; set; }
        public Vertex SelectedC2 { get; set; }

        private AdiacencyList _adiacencyList = new AdiacencyList();
        public AdiacencyListInputViewModel()
        {
            AdiacencyList = _adiacencyList.ToAdiacencyList();
            GraphContext.Instance.Add(this);
        }

        private bool ValidSelectedVertices()
        {
            if (SelectedC1 == null || SelectedC2 == null || SelectedC1.Equals(SelectedC2))
            {
                return false;
            }
            if (Find().Any()) return false;
            return true;
        }

        private IEnumerable<Edge> Find()
        {
            return Edges.Where(i => SelectedC1.Equals(i.Source) && SelectedC2.Equals(i.Target) || SelectedC1.Equals(i.Target) && SelectedC2.Equals(i.Source));
        }

        public RelayCommand RemoveEdge => new RelayCommand((param) =>
        {
            var a = Find();
            if (!a.Any()) return;
            Edges.Remove(Find().FirstOrDefault());
            GraphContext.Instance.NotifyObservers(null);
        });


        public RelayCommand AddEdge => new RelayCommand((param) =>
        {
            if (!ValidSelectedVertices()) return;
            Edges.Add(new Edge("", SelectedC1, SelectedC2));
            GraphContext.Instance.NotifyObservers(null);
        });

        public void Notify()
        {
            AdiacencyList = _adiacencyList.ToAdiacencyList();
            OnPropertyChanged(nameof(AdiacencyList));
            OnPropertyChanged(nameof(Vertices));
            OnPropertyChanged(nameof(Edges));
        }
    }
}
