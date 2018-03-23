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
