using Graphs.Configuration;
using Graphs.Views.Converters;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace Graphs.ViewModels
{
    public class StartupWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> AvailableLanguages { get { return new ObservableCollection<string>(LocalizationExtensions.GetSupportedLangs()); } }
        private string _selectedLanguage = LocalizationConfig.ActualCultureCode();

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                RefreshCulture(value);
            }
        }

        //TODO: Replace with command
        private void RefreshCulture(string value)
        {
            CultureInfo.CurrentCulture.Configure(value);
            var oldWindow = Application.Current.MainWindow;
            Application.Current.MainWindow = new StartupWindow();
            Application.Current.MainWindow.Show();
            oldWindow.Close();
        }
    }
}