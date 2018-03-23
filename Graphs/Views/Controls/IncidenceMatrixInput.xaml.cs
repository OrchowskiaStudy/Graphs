using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphs.Views.Controls
{
    /// <summary>
    /// Interaction logic for IncidenceMatrixInput.xaml
    /// </summary>
    public partial class IncidenceMatrixInput : UserControl, IObserver
    {
        public IncidenceMatrixInput()
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
