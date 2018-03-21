using Graphs.ViewModels;
using Graphs.Views.Models;
using GraphSharp.Controls;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Graphs.Views.Pages
{
    /// <summary>
    /// Interaction logic for GraphVisualizationPage.xaml
    /// </summary>
    public partial class GraphVisualizationPage : PageBase
    {
        private GraphVisualisationViewModel _viewModel;

        public GraphVisualizationPage()
        {
            InitializeComponent();
            _viewModel = DataContext as GraphVisualisationViewModel;
        }

        private void OnVertexClick(object o, object e)
        {
            _viewModel.SelectVertex.Execute(o);
        }
        private void OnVertexRightClick(object o, object e)
        {
            _viewModel.RemoveVertex.Execute(o);
        }
        
        private void OnEdgeClick(object o, object e)
        {
            _viewModel.SelectEdge.Execute(o);
        }
    }
}
