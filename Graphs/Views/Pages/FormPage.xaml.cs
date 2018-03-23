using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Windows.Input;

namespace Graphs.Views.Pages
{
    public partial class FormPage : PageBase
    {
        public FormPage()
        {
            InitializeComponent();
        }

        public override void Notify()
        {
            base.Notify();
            var tmp = lv.DataContext;
            lv.DataContext = null;
            lv.DataContext = tmp;

            tmp = le.DataContext;
            le.DataContext = null;
            le.DataContext = tmp;
        }

        private void VerticeNameUpdate(object sender, KeyEventArgs e)
        {
            if (sender is Vertex vertex)
            {
                vertex.OnPropertyChanged(nameof(vertex.Name));
                GraphContext.Instance.NotifyObservers(this);
            }
        }

        private void EdgeWeightUpdate(object sender, KeyEventArgs e)
        {
            if(sender is Edge edge)
            {
                edge.OnPropertyChanged(nameof(edge.Weight));
                GraphContext.Instance.NotifyObservers(this);
            }
        }
    }
}