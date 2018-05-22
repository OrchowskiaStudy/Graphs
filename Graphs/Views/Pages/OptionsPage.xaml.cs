using Graphs.Models.BL;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System.Windows.Input;

namespace Graphs.Views.Pages
{
    public partial class OptionsPage : PageBase
    {
        public OptionsPage()
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
            if (sender is Edge edge)
            {
                edge.OnPropertyChanged(nameof(edge.Weight));
                GraphContext.Instance.NotifyObservers(this);
            }
        }
    }
}