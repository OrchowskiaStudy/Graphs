using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using System.Windows;
using System.Windows.Controls;

namespace Graphs.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdiacencyMatrixInput.xaml
    /// </summary>
    public partial class GraphCyclesControl : UserControl, IObserver
    {
        public GraphCyclesControl()
        {
            InitializeComponent();
            GraphContext.Instance.Add(this);
            this.IsVisibleChanged += OnVisibilityChanged;
        }

        private void OnVisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        public void Notify()
        {
        }
    }
}