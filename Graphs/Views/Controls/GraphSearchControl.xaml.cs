using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using System.Windows;
using System.Windows.Controls;

namespace Graphs.Views.Controls
{
    /// <summary>
    /// Graph search control code behind
    /// </summary>
    public partial class GraphSearchControl : UserControl, IObserver
    {
        public GraphSearchControl()
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
            var tmp = lv.DataContext;
            lv.DataContext = null;
            lv.DataContext = tmp;
        }
    }
}