using Graphs.Configuration;
using Graphs.Models.BL;
using Graphs.Models.BL.Enumerations;
using Graphs.Views.Commands;
using Graphs.Views.Converters;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Graphs.ViewModels
{
    public class StartupWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> AvailableLanguages { get { return new ObservableCollection<string>(LocalizationExtensions.GetSupportedLangs()); } }
        public ObservableCollection<ColorOrders> ColoringOrders
        {
            get
            {
                return new ObservableCollection<ColorOrders>() {
            ColorOrders.ByAdiacencyMatrix,ColorOrders.ByVertexDegrees,ColorOrders.Random
        };
            }
        }

        public ColorOrders SelectedColoring { get; set; }

        private string _selectedLanguage = LocalizationConfig.ActualCultureCode();

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                RefreshCulture(value);
            }
        }

        private void RefreshCulture(string value)
        {
            CultureInfo.CurrentCulture.Configure(value);
            var oldWindow = Application.Current.MainWindow;
            Application.Current.MainWindow = new StartupWindow();
            Application.Current.MainWindow.Show();
            oldWindow.Close();
        }

        public StartupWindowViewModel()
        {
            SelectedColoring = ColoringOrders[0];
        }

        public RelayCommand CreateNewGraph => new RelayCommand((sender) =>
        {
            GraphContext.ClearEdges();
            GraphContext.ClearVertices();
            GraphContext.Instance.NotifyObservers(null);
        });

        public RelayCommand ColorGraph => new RelayCommand((sender) =>
        {
            var vertices = GraphContext.Instance.Vertices;
            var edges = GraphContext.Instance.Edges;
            switch (SelectedColoring)
            {
                case ColorOrders.ByVertexDegrees:
                    vertices = new VertexDegreeComputer(edges, vertices).Compute().OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
                    break;
                case ColorOrders.Random:
                    var rnd = new Random();
                    vertices = vertices.OrderBy(x => rnd.Next()).ToList();
                    break;
                default:
                    break;
            }
            new VerticesPainter(vertices, edges).MakeYourLifeMoreColorfull();
            GraphContext.Instance.NotifyObservers(null);
        });
    }
}