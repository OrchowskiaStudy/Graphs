using Graphs.Views.Pages;
using System.Windows;

namespace Graphs
{
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _left.Navigate(new GraphVisualizationPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _right.Navigate(new FormPage());
        }
    }
}