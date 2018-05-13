using Graphs.Models.Vertices;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Graphs.Views.Converters
{
    public class VertexToColorConverter : IValueConverter
    {
        public Brush DefaultColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush result = DefaultColor;
            if (value is Vertex vertex)
            {
                if (vertex.CustomColor != null)
                {
                    result = vertex.CustomColor;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as Brush != null;
        }
    }
}