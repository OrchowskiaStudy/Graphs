using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using System.Windows.Controls;

namespace Graphs.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdjacencyListInput.xaml
    /// </summary>
    public partial class AdjacencyListInput : UserControl, IObserver
    {
        public AdjacencyListInput()
        {
            InitializeComponent();
            GraphContext.Instance.Add(this);
        }

        public void Notify()
        {
            var tmp = lv.DataContext;
            lv.DataContext = null;
            lv.DataContext = tmp;

            c1.Items.Refresh();
            c2.Items.Refresh();
        }
    }
}