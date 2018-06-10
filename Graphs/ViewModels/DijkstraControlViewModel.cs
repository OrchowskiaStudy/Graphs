using Graphs.Models.BL;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using Graphs.Views.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Graphs.ViewModels
{
    public class DijkstraControlViewModel : ViewModelBase
    {
        private List<Vertex> _vertices = GraphContext.Instance.Vertices;
        private List<Edge> _edges = GraphContext.Instance.Edges;
        public DijkstraControlViewModel()
        {
        }

        public RelayCommand FindPaths => new RelayCommand((sender) =>
        {
            var start = _vertices.FirstOrDefault(v => v.IsSelected);
            if (_vertices.Count < 3 || start == null)
            {
                MessageBox.Show("Nie uzupełniłeś grafu, lub nie wybrałeś wierzchołka startowego");
                return;
            }
            var Q = new VertexFamilyFactory(_edges).CreateFamilies(_vertices).ToList();
            var S = new List<VertexFamily>();

            var d = new int[Q.Count];
            var p = new string[Q.Count];
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = 99999;
                p[i] = string.Empty;
            }
            var familyStart = Q.FirstOrDefault(x => x.Parent == start);
            d[_vertices.IndexOf(start)] = 0;


            do
            {
                ///FirstOrDefault(x=> _vertices[d.ToList().IndexOf(tmp)] == x.Parent);
                familyStart = Q.OrderBy(x => d[_vertices.IndexOf(_vertices.FirstOrDefault(a=>a==x.Parent))]).First();
                Q.Remove(familyStart);
                S.Add(familyStart);
                var nearEdges = ToEdges(S, familyStart);
                nearEdges.ForEach(x =>
                {
                    var vertex = x.Target == familyStart.Parent ? x.Source : x.Target;
                    var index = _vertices.IndexOf(vertex);
                    var indexStart = _vertices.IndexOf(familyStart.Parent);

                    if (d[index] > d[indexStart] + x.Weight)
                    {
                        d[index] = d[indexStart] + x.Weight;
                        p[index] = familyStart.Parent.Id;
                    }

                });
            } while (Q.Any());


            GenerateResults(d, p, _vertices);




        });


        public List<string> Results { get; set; } = new List<string>();


        private void GenerateResults(int[] d, string[] p, List<Vertex> u)
        {
            Results.Clear();
            var P = p.ToList();
            var D = d.ToList();
            var startIndex = P.IndexOf(string.Empty);
            for (int i = 0; i < u.Count; i++)
            {
                var jakasLista = new List<string>();
                var last = p[i];
                do
                {
                    jakasLista.Add(string.IsNullOrEmpty(last) ? "start" : last);
                    if (!string.IsNullOrEmpty(last))
                    {
                        last = p[u.IndexOf(u.First(x => x.Id == last))];
                    }

                } while (!string.IsNullOrEmpty(last));
                
                jakasLista.Reverse();
                Results.Add(u[i].Id + ":  "+String.Join(LIST_SEPARATOR, jakasLista)  + "   koszt:" + d[i]);
            }
            GraphContext.Instance.NotifyObservers(null);
            OnPropertyChanged(nameof(Results));
        }
        private const string LIST_SEPARATOR = "⬌";

        private List<Edge> ToEdges(List<VertexFamily> S, VertexFamily familyStart)
        {
            var a = _edges
           .Where(x =>
           {
               var heh = familyStart.Childrens.Except(S.Select(w => w.Parent));
               var ss = x.Source == familyStart.Parent && heh.Contains(x.Target) || x.Target == familyStart.Parent && heh.Contains(x.Source);
               return ss;
           }).ToList().OrderBy(x => x.Weight).ToList();
            return a;
        }
    }
}
