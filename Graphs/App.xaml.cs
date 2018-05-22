using Graphs.Configuration;
using Graphs.Models.BL;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;

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
            this.DispatcherUnhandledException += OnFatalError;
        }

        private void OnFatalError(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Debug.WriteLine("WTF: fix IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.WriteLine(e.Exception.StackTrace);
            Debug.WriteLine("WTF: fix IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            GraphContext.ClearEdges();
            GraphContext.ClearVertices();
            GraphContext.Instance.NotifyObservers(null);
        }
    }
}