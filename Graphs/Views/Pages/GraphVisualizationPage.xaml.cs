using Graphs.ViewModels;

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