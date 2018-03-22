using Graphs.Configuration;
using System.Globalization;
using System.Windows;

namespace Graphs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CultureInfo.CurrentCulture.Configure(Defaults.CULTURE_NAME);
        }
    }
}