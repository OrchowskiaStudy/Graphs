using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Graphs.Views.Pages
{
    public class PageBase : Page, IObserver
    {
        public string ViewNameKey { get; set; }

        public PageBase() : base()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            GraphContext.Instance.Add(this);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            GraphContext.Instance.Remove(this);
        }

        public virtual void Notify()
        {
            Debug.WriteLine($"View: {this.ViewNameKey} notified by Observable");
        }
    }
}