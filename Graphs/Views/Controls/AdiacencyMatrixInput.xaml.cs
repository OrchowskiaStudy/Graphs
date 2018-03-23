using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using Graphs.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Graphs.Views.Controls
{
    /// <summary>
    /// Interaction logic for AdiacencyMatrixInput.xaml
    /// </summary>
    public partial class AdiacencyMatrixInput : UserControl, IObserver
    {
        public AdiacencyMatrixInput()
        {
            InitializeComponent();
            GraphContext.Instance.Add(this);
        }

        public void Notify()
        {
            var tmp = lv.DataContext;
            lv.DataContext = null;
            lv.DataContext = tmp;

            tmp = eIds.DataContext;
            eIds.DataContext = null;
            eIds.DataContext = tmp;

            tmp = vIds.DataContext;
            vIds.DataContext = null;
            vIds.DataContext = tmp;
        }
    }
}