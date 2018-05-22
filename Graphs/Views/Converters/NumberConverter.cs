using System;
using System.Globalization;
using System.Windows.Data;

namespace Graphs.Views.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = value.ToString();
            if (int.TryParse(number, out int result))
            {
                return result;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}